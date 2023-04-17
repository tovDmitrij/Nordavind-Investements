using database.context.Models.Data.Account;
using database.context.Models.Events.MainEvents;
using database.context.Models.Events.FlipEvents;
using database.context.Models.Events.SellEvents;

namespace database.context.Repos.Account
{
    public class AccountRepos : IAccountRepos
    {
        private readonly DataContext _db;
        public AccountRepos(DataContext db) => _db = db;

        public void AddAccount(int id, string title, int type, int ownership_type, int currency_type, int condition_type, int bot_type)
        {
            _db.TableAccounts.Add(new(type, currency_type, condition_type, ownership_type, bot_type, title, DateTime.Now));
            _db.SaveChanges();

        }


        #region Get-методы для получения данных об аккаунте

        public AccountDetailModel GetAccountDetail(int acc_id) => _db.TableAccountDetails.Single(acc_details => acc_details.AccountId == acc_id);

        public IEnumerable<AccountModel> GetAccountList() => _db.TableAccounts.ToList();

        public IEnumerable<HistoryMainEventModel> GetMainEvents(int acc_id) => _db.TableHistoryMainEvents
                .Where(e => e.AccountId == acc_id);
        public IEnumerable<HistoryFlipEventModel> GetFlipEvents(int acc_id) => _db.TableHistoryFlipEvents
                .Where(e => e.AccountFrom == acc_id || e.AccountTo == acc_id);

        public IEnumerable<HistorySellEventModel> GetSellEvents(int acc_id) => _db.TableHistorySellEvents
            .Where(e => e.AccountId == acc_id);

        #endregion


        #region Методы проверки существования объектов в таблицах

        public bool IsAccountExits(int acc_id) => _db.TableAccounts.Any(acc => acc.ID == acc_id);

        public bool IsAccountTypeExists(int acc_type) => _db.TableAccountTypes.Any(acc => acc.ID == acc_type);

        public bool IsBotTypeExists(int bot_type) => _db.TableBotTypes.Any(bot => bot.ID == bot_type);

        public bool IsCoditionTypeExists(int condition_type) => _db.TableConditions.Any(cond => cond.ID == condition_type);

        public bool IsCurrencyTypeExists(int currency_type) => _db.TableCurrencies.Any(cur => cur.ID == currency_type);

        public bool IsOwnershipTypeExists(int ownership_type) => _db.TableOwnerships.Any(ownership => ownership.ID == ownership_type);

        #endregion
    }
}
