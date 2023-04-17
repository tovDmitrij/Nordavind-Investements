using Microsoft.AspNetCore.Mvc;
using misc.security;
using Microsoft.Net.Http.Headers;
using api.Misc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using database.context.Repos.Directory;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryRepos _directory;
        public DirectoryController(IDirectoryRepos db) => _directory = db;


        #region Обработчики get-запросов

        [HttpGet("Сurrencies/Get")]
        public IActionResult GetCurrencies() 
        {
            var currencies = _directory.GetCurrencies();
            if (!currencies.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new {status="Список был успешно сформирован", 
                data=currencies });
        }

        [HttpGet("AccountTypes/Get")]
        public IActionResult GetAccountTypes() 
        {
            var accountTypes = _directory.GetAccountTypes();
            if (!accountTypes.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "Списик был успешно сформирован", 
                data = accountTypes});
        }

        [HttpGet("BotTypes/Get")]    
        public IActionResult GetBotTypes() 
        {
            var botTypes = _directory.GetBotTypes();
            if (!botTypes.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "Список был успешно сформирован", 
                data=botTypes});
        }

        [HttpGet("Conditions/Get")]
        public IActionResult GetConditions() 
        {
            var conditions = _directory.GetConditions();
            if (!conditions.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new {status="Список был успешно сформирован",
                data=conditions});
        }

        [HttpGet("Operations/Get")]
        public IActionResult GetOperations()
        {
            var operations = _directory.GetOperations();
            if (!operations.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "Список был успешно сформирован", data=operations});
        }

        [HttpGet("Funds/Get")]
        public IActionResult GetFunds()
        {
            var funds = _directory.GetFunds();
            if (!funds.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "Списк был успешно сформирован", data = funds });
        }

        #endregion


        #region Обработчики post-запросов

        [HttpPost("Currencies/Add/title={title}&short_title={short_title}")]
        public IActionResult AddCurrencies(string title, string short_title) 
        {
            _directory.AddCurrency( new (title, short_title) );
            return StatusCode(200, new { status = "Валюта была успешно добавлена" });
        }

        [HttpPost("AccountTypes/Add/title={title}&description={description}")]
        public IActionResult AddAccountTypes(string title, string description)
        {
            _directory.AddAccountType(new (title, description) );
            return StatusCode(200, new { status = "Новый тип аккаунта был успешно добавлен" });
        }

        [HttpPost("BotTypes/Add/title={title}&description={description}")]
        public IActionResult AddBotTypes(string title, string description) 
        {
            _directory.AddBotType(new(title, description));
            return StatusCode(200, new { status = "Новый тип бота был успешно добавлен" });
        }

        [HttpPost("Conditions/Add/title={title}&value={value}&description={description}")]
        public IActionResult AddConditions(string title, decimal value, string description) 
        {
            _directory.AddCondition(new(title, value, description));
            return StatusCode(200, new { status = "Новые условия были успешно добавлены" });
        }

        #endregion


        #region Обработчики put-запросов

        [HttpPut("Currencies/Update/id={id}&title={title}&short_title={short_title}")]
        public IActionResult UpdateCurrencies(int id, string title, string short_title)
        {
            if (!_directory.IsCurrencyExists(id))
                return StatusCode(404, new { status = "Данной валюты не существует" });
            _directory.UpdateCurrency(id, title, short_title);
            return StatusCode(200, new { status = "Валюта была успешно обновлена" });
        }

        [HttpPut("Conditions/Update/id={id}&title={title}&value={value}&description={description}")]
        public IActionResult UpdateConditions(int id, string title, decimal value, string description)
        {
            if (!_directory.IsConditionExists(id))
                return StatusCode(404, new { status = "Данного условия не существует" });
            _directory.UpdateCondition(id, title, value, description);
            return StatusCode(200, new { status = "Условие было успешно обновлено" });
        }

        [HttpPut("AccountTypes/Update/id={id}&title={title}&description={description}")]
        public IActionResult UpdateAccountTypes(int id, string title, string description)
        {
            if (!_directory.IsAccountTypeExists(id))
                return StatusCode(404, new { status = "Данного типа аккаунта не существует" });
            _directory.UpdateAccountType(id, title, description);
            return StatusCode(200, new { status = "Тип аккаунта успешно обновлён" });
        }

        [HttpPut("BotTypes/Update/id={id}&title={title}&description={description}")]
        public IActionResult UpdateBotTypes(int id, string title, string description)
        {
            if (!_directory.IsBotTypeExists(id))
                return StatusCode(404, new { status = "Данного типа бота не сущетсвует" });
            _directory.UpdateBotType(id, title, description);
            return StatusCode(200, new { status = "Бот был успешно обновлён" });
        }

        #endregion


        #region Обработчики delete-запросов

        [HttpDelete("Currencies/Delete/id={id}")]
        public IActionResult DeleteCurrencies(int id)
        {
            if (!_directory.IsCurrencyExists(id))
                return StatusCode(404, new { status = "Данной валюты не сущетсвует" });
            _directory.DeleteCurrency(id);
            return StatusCode(200, new { status = "Валюта была успешно удалена" });
        }

        [HttpDelete("Conditions/Delete/id={id}")]
        public IActionResult DeleteCondition(int id)
        {
            if (!_directory.IsConditionExists(id))
                return StatusCode(404, new { status = "Данного условия не существует" });
            _directory.DeleteCondition(id);
            return StatusCode(200, new { status = "Условие было успешно удалено" });
        }

        [HttpDelete("AccountTypes/Delete/id={id}")]
        public IActionResult DeleteAccountTypes(int id)
        {
            if (!_directory.IsAccountTypeExists(id))
                return StatusCode(404, new { status = "Данного типа аккаунта не существует" });
            return StatusCode(200, new { status = "Тип аккаунта был удалён" });
        }

        [HttpDelete("BotTypes/Delete/id={id}")]
        public IActionResult DeleteBotTypes(int id)
        {
            if (!_directory.IsBotTypeExists(id))
                return StatusCode(404, new { status = "Данного типа бота не сущетсвует" });
            return StatusCode(200, new { status = "Тип бота был успешно удалён" });
        }

        #endregion


    }
}
