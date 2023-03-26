using Microsoft.AspNetCore.Mvc;
using database.context.Repos;
using misc.security;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepos _db;

        public AccountController(IUserRepos db) => _db = db;

        [HttpPost]
        [Route("signUp")]
        public IActionResult SignUp(string email, string password, string surname, string name, string? patronymic)
        {
            if (_db.GetByEmail(email) != null)
            {
                return StatusCode(406, "Почта уже занята");
            }

            try
            {
                string hashedPass = Security.HashPassword(email, password);
                _db.Add(email, hashedPass, surname, name, patronymic);
            }
            catch (Exception e) 
            { 
                return StatusCode(406, e.Message);
            }

            return StatusCode(200, "Пользователь успешно зарегистрирован");
        }

        [HttpPost]
        [Route("signIn")]
        public IActionResult SignIn(string email, string password)
        {
            string hashedPass = Security.HashPassword(email, password);
            if (_db.GetByEmailAndPassword(email, hashedPass) == null)
            {
                return StatusCode(404, "Пользователя с такой почтой и паролем не существует");
            }

            return StatusCode(200, "Пользователь найден");
        }
    }
}