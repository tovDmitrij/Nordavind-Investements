using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using api.Misc;
using database.context.Repos.User;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepos _userRepos;

        public AuthController(IUserRepos db) => _userRepos = db;

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        [HttpPost("SignUp/email={email}&password={password}")]
        public IActionResult SignUp(string email, string password)
        {
            switch (_userRepos.IsEmailBusy(email))
            {
                case true:
                    return StatusCode(406, new { status = "Почта уже занята другим пользователем" });

                case false:
                    _userRepos.Add(email, password);
                    return StatusCode(200, new { status = "Пользователь успешно зарегистрирован" });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        [ProducesResponseType(typeof(Status), 200)]
        [HttpPost("SignIn/email={email}&password={password}")]
        public IActionResult SignIn(string email, string password)
        {
            switch (_userRepos.IsUserExist(email, password))
            {
                case true:
                    JwtSecurityToken token = new(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: new List<Claim> {
                            new(ClaimTypes.Name, email)
                        },
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));

                    return StatusCode(200, new { 
                            status = "Пользователь успешно найден",
                            token = new JwtSecurityTokenHandler().WriteToken(token)});

                case false:
                    return StatusCode(404, new { status = "Пользователя с такой почтой и паролем не существует" });
            }
        }

        private record Status(string token);
    }
}