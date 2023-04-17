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
        private readonly IUserRepos _user;

        public AuthController(IUserRepos db) => _user = db;

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(406)]
        [HttpPost("SignUp/email={email}&password={password}")]
        public IActionResult SignUp(string email, string password)
        {
            switch (_user.IsEmailBusy(email))
            {
                case true:
                    return StatusCode(406, new { status = "Почта уже занята другим пользователем" });

                case false:
                    _user.Add(email, password);
                    return StatusCode(200, new { status = "Пользователь успешно зарегистрирован" });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPost("SignIn/email={email}&password={password}")]
        public IActionResult SignIn(string email, string password)
        {
            switch (_user.IsUserExist(email, password))
            {
                case true:
                    var userInfo = _user.GetUserInfo(email, password);

                    JwtSecurityToken token = new(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: new List<Claim> {
                            new(ClaimTypes.Name, email)
                        },
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));

                    return StatusCode(200, new 
                        { 
                            status = "Пользователь успешно найден",
                            id = userInfo.ID,
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });

                case false:
                    return StatusCode(404, new { status = "Пользователя с такой почтой и паролем не существует" });
            }
        }
    }
}