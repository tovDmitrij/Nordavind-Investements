using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using database.context.Models.Data;
using database.context.Repos.Directory;

namespace api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryRepos _directoryRepos;

        public DirectoryController(IDirectoryRepos db) => _directoryRepos = db;



        #region GET

        [ProducesResponseType(typeof(IEnumerable<CurrencyModel>), 200)]
        [HttpGet("Сurrencies/Get")]
        public IActionResult GetCurrencies() 
        {
            var currencies = _directoryRepos.GetCurrencies();
            if (!currencies.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });

            return StatusCode(200, new { status = "Список был успешно сформирован", data = currencies });
        }

        [ProducesResponseType(typeof(IEnumerable<AccountTypeModel>), 200)]
        [HttpGet("AccountTypes/Get")]
        public IActionResult GetAccountTypes() 
        {
            var accountTypes = _directoryRepos.GetAccountTypes();
            if (!accountTypes.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });

            return StatusCode(200, new { status = "Списик был успешно сформирован", data = accountTypes});
        }

        [ProducesResponseType(typeof(IEnumerable<BotTypeModel>), 200)]
        [HttpGet("BotTypes/Get")]    
        public IActionResult GetBotTypes() 
        {
            var botTypes = _directoryRepos.GetBotTypes();
            if (!botTypes.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });

            return StatusCode(200, new { status = "Список был успешно сформирован", data = botTypes });
        }

        [ProducesResponseType(typeof(IEnumerable<ConditionModel>), 200)]
        [HttpGet("Conditions/Get")]
        public IActionResult GetConditions() 
        {
            var conditions = _directoryRepos.GetConditions();
            if (!conditions.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });

            return StatusCode(200, new { status = "Список был успешно сформирован", data = conditions });
        }

        [ProducesResponseType(typeof(IEnumerable<OperationModel>), 200)]
        [HttpGet("Operations/Get")]
        public IActionResult GetOperations()
        {
            var operations = _directoryRepos.GetOperations();
            if (!operations.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });

            return StatusCode(200, new { status = "Список был успешно сформирован", data = operations });
        }

        [ProducesResponseType(typeof(IEnumerable<FundModel>), 200)]
        [HttpGet("Funds/Get")]
        public IActionResult GetFunds()
        {
            var funds = _directoryRepos.GetFunds();
            if (!funds.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });

            return StatusCode(200, new { status = "Список был успешно сформирован", data = funds });
        }

        #endregion



        #region POST

        [HttpPost("Currencies/Add/title={title}&short_title={short_title}")]
        public IActionResult AddCurrency(string title, string short_title) 
        {
            _directoryRepos.AddCurrency( new (title, short_title) );
            return StatusCode(200, new { status = "Валюта была успешно добавлена" });
        }

        [HttpPost("AccountTypes/Add/title={title}&description={description}")]
        public IActionResult AddAccountType(string title, string description)
        {
            _directoryRepos.AddAccountType(new (title, description) );
            return StatusCode(200, new { status = "Новый тип счёта был успешно добавлен" });
        }

        [HttpPost("BotTypes/Add/title={title}&description={description}")]
        public IActionResult AddBotType(string title, string description) 
        {
            _directoryRepos.AddBotType(new(title, description));
            return StatusCode(200, new { status = "Новый тип бота был успешно добавлен" });
        }

        [HttpPost("Conditions/Add/title={title}&value={value}&description={description}")]
        public IActionResult AddCondition(string title, decimal value, string description) 
        {
            _directoryRepos.AddCondition(new(title, value, description));
            return StatusCode(200, new { status = "Новые условия были успешно добавлены" });
        }

        #endregion



        #region PUT

        [HttpPut("Currencies/Update/id={id}&title={title}&short_title={short_title}")]
        public IActionResult UpdateCurrency(int id, string title, string short_title)
        {
            if (!_directoryRepos.IsCurrencyExists(id))
                return StatusCode(404, new { status = "Данной валюты не существует" });

            _directoryRepos.UpdateCurrency(id, title, short_title);
            return StatusCode(200, new { status = "Валюта была успешно обновлена" });
        }

        [HttpPut("Conditions/Update/id={id}&title={title}&value={value}&description={description}")]
        public IActionResult UpdateCondition(int id, string title, decimal value, string description)
        {
            if (!_directoryRepos.IsConditionExists(id))
                return StatusCode(404, new { status = "Данного условия не существует" });

            _directoryRepos.UpdateCondition(id, title, value, description);
            return StatusCode(200, new { status = "Условие было успешно обновлено" });
        }

        [HttpPut("AccountTypes/Update/id={id}&title={title}&description={description}")]
        public IActionResult UpdateAccountType(int id, string title, string description)
        {
            if (!_directoryRepos.IsAccountTypeExists(id))
                return StatusCode(404, new { status = "Данного типа аккаунта не существует" });

            _directoryRepos.UpdateAccountType(id, title, description);
            return StatusCode(200, new { status = "Тип аккаунта успешно обновлён" });
        }

        [HttpPut("BotTypes/Update/id={id}&title={title}&description={description}")]
        public IActionResult UpdateBotType(int id, string title, string description)
        {
            if (!_directoryRepos.IsBotTypeExists(id))
                return StatusCode(404, new { status = "Данного типа бота не сущетсвует" });

            _directoryRepos.UpdateBotType(id, title, description);
            return StatusCode(200, new { status = "Бот был успешно обновлён" });
        }

        #endregion



        #region DELETE

        [HttpDelete("Currencies/Delete/id={id}")]
        public IActionResult DeleteCurrency(int id)
        {
            if (!_directoryRepos.IsCurrencyExists(id))
                return StatusCode(404, new { status = "Данной валюты не сущетсвует" });

            _directoryRepos.DeleteCurrency(id);
            return StatusCode(200, new { status = "Валюта была успешно удалена" });
        }

        [HttpDelete("Conditions/Delete/id={id}")]
        public IActionResult DeleteCondition(int id)
        {
            if (!_directoryRepos.IsConditionExists(id))
                return StatusCode(404, new { status = "Данного условия не существует" });

            _directoryRepos.DeleteCondition(id);
            return StatusCode(200, new { status = "Условие было успешно удалено" });
        }

        [HttpDelete("AccountTypes/Delete/id={id}")]
        public IActionResult DeleteAccountType(int id)
        {
            if (!_directoryRepos.IsAccountTypeExists(id))
                return StatusCode(404, new { status = "Данного типа аккаунта не существует" });

            _directoryRepos.DeleteAccountType(id);
            return StatusCode(200, new { status = "Тип аккаунта был удалён" });
        }

        [HttpDelete("BotTypes/Delete/id={id}")]
        public IActionResult DeleteBotType(int id)
        {
            if (!_directoryRepos.IsBotTypeExists(id))
                return StatusCode(404, new { status = "Данного типа бота не сущетсвует" });

            _directoryRepos.DeleteBotType(id);
            return StatusCode(200, new { status = "Тип бота был успешно удалён" });
        }

        #endregion



    }
}