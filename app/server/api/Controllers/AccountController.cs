using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Account;
using Microsoft.AspNetCore.Authorization;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepos _accountRepos;

        public AccountController(IAccountRepos db) => _accountRepos = db;



        #region GET

        [HttpGet("Get")]
        public IActionResult GetAccounts()
        {
            var accounts = _accountRepos.GetAccountList();
            if (!accounts.Any())
                return StatusCode(404, new { status = "Список счетов пуст" });
            return StatusCode(200, new { status = "Список счетов был успешно сформирован", data = accounts });
        }

        [HttpGet("acc_id={acc_id:int}/Details/Get")]
        public IActionResult GetAccountDetails(int acc_id)
        {
            if (!_accountRepos.IsAccountExits(acc_id))
                return StatusCode(404, new { status = "Счёта с заданным идентификатором не существует" });
            var details = _accountRepos.GetAccountDetail(acc_id);
            return StatusCode(200, new { status = "Информация о счёте была успешно сформирована", data = details });
        }

        [HttpGet("acc_id={acc_id:int}/Events/Get")]
        public IActionResult GetAccountEvents(int acc_id)
        {
            if(!_accountRepos.IsAccountExits(acc_id))
                return StatusCode(404, new { status = "Счёта с заданным идентификатором не существует" });

            var mainEvents = _accountRepos.GetMainEvents(acc_id);
            var flipEvents = _accountRepos.GetFlipEvents(acc_id);
            var sellEvents = _accountRepos.GetSellEvents(acc_id);
            return StatusCode(200, new { 
                status = "Списки событий счёта были успешно сформированы",
                mainEvents,
                flipEvents,
                sellEvents
            });
        }

        #endregion



        [HttpPost("Add/acc_title={acc_title}&acc_type={acc_type:int}&ownership_type={ownership_type:int}&condition_type={condition_type:int}&bot_type={bot_type:int}")]
        public IActionResult AddAсcount(string acc_title, int acc_type, int ownership_type, int currency_type, int condition_type, int bot_type)
        {
            if (!_accountRepos.IsAccountTypeExists(acc_type))
                return StatusCode(404, new { status = "Данного типа счёта не существует" });
            if (!_accountRepos.IsOwnershipTypeExists(ownership_type))
                return StatusCode(404, new { status = "Данного типа статуса принадлежности не существует"});
            if (!_accountRepos.IsCurrencyTypeExists(currency_type))
                return StatusCode(404, new { status = "Данного типа валюты не существует"});
            if(!_accountRepos.IsCoditionTypeExists(condition_type))
                return StatusCode(404, new { status = "Данного типа условия не существует" });
            if(!_accountRepos.IsBotTypeExists(bot_type))
                return StatusCode(404, new { status = "Данного типа бота не существует" });

            _accountRepos.AddAccount(acc_title, acc_type, ownership_type, currency_type, condition_type, bot_type);
            return StatusCode(200, new { status = "Счёт был успешно добавлен" });
        }
    }
}
