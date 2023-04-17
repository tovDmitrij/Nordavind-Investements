using Microsoft.AspNetCore.Mvc;
using misc.security;
using Microsoft.Net.Http.Headers;
using api.Misc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using database.context.Repos.Account;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepos _accountRepos;

        public AccountController(IAccountRepos db) => _accountRepos = db;


        #region обработчики get-запросов

        [HttpGet("Accounts/Get")]
        public IActionResult GetAccounts()
        {
            var accounts = _accountRepos.GetAccountList();
            if (!accounts.Any())
                return StatusCode(404, new { status = "Счета не найдены" });
            return StatusCode(200, new { status = "Список счетов найден", data = accounts });
        }

        [HttpGet("Account/acc_id={acc_id:int}/Details/Get")]
        public IActionResult GetAccountDetails(int acc_id)
        {
            if (!_accountRepos.IsAccountExits(acc_id))
                return StatusCode(404, new { status = "Аккаунт не найден" });
            var details = _accountRepos.GetAccountDetail(acc_id);
            return StatusCode(200, new { status = "Профиль акканута найден", data = details });
        }

        [HttpGet("Account/acc_id={acc_id:int}/Events/Get")]
        public IActionResult GetAccountEvents(int acc_id)
        {
            if(!_accountRepos.IsAccountExits(acc_id))
                return StatusCode(404, new { status = "Аккаунт не найден" });

            var mainEvents = _accountRepos.GetMainEvents(acc_id);
            var flipEvents = _accountRepos.GetFlipEvents(acc_id);
            var sellEvents = _accountRepos.GetSellEvents(acc_id);
            return StatusCode(200, new { status = "События данного аккаунта найдены", mainEvents = mainEvents, flipEvents = flipEvents, sellEvents = sellEvents });
        }

        #endregion


        [HttpPost("Accounts/Add/acc_id={acc_id:int}&acc_title={acc_title}&acc_type={acc_type:int}&ownership_type={ownership_type:int}&codition_type={codition_type:int}&bot_type={bot_type:int}")]
        public IActionResult AddACcount(int acc_id, string acc_title, int acc_type, int ownership_type, int currency_type, int condition_type, int bot_type)
        {
            if(_accountRepos.IsAccountExits(acc_id))
                return StatusCode(404, new {status="Аккаунт уже существует"});
            if (!_accountRepos.IsAccountTypeExists(acc_type))
                return StatusCode(404, new { status = "Данного типа аккаунта не существует" });
            if (!_accountRepos.IsOwnershipTypeExists(ownership_type))
                return StatusCode(404, new { status = "Данного статуса не существует"});
            if (!_accountRepos.IsCurrencyTypeExists(currency_type))
                return StatusCode(404, new { status = "Данной валюты не существует"});
            if(!_accountRepos.IsCoditionTypeExists(condition_type))
                return StatusCode(404, new { status = "Данного условия не существует" });
            if(!_accountRepos.IsBotTypeExists(bot_type))
                return StatusCode(404, new { status = "Данного бота не существует" });
            _accountRepos.AddAccount(acc_id,acc_title, acc_type, ownership_type, currency_type, condition_type, bot_type);
            return StatusCode(200, new { status = "Аккаунт добавлен" });
        }
    }
}
