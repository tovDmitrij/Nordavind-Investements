using database.context.Models.Data.Account;
using database.context.Models.Events.MainEvents;
using database.context.Models.Events.FlipEvents;
using database.context.Models.Events.SellEvents;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.context.Repos.Account
{
    public interface IAccountRepos
    {

        public void AddAccount(int id, string title, int type, int ownership_type, int currency_type, int condition_type, int bot_type);


        #region Get-методы для получения данных об аккаунте

        public IEnumerable<AccountModel> GetAccountList();

        public AccountDetailModel GetAccountDetail(int id);

        public IEnumerable<HistoryMainEventModel> GetMainEvents(int acc_id);

        public IEnumerable<HistoryFlipEventModel> GetFlipEvents(int acc_id);

        public IEnumerable<HistorySellEventModel> GetSellEvents(int acc_id);

        #endregion


        #region Методы проверки существования объектов в таблицах

        public bool IsAccountExits(int acc_id);

        public bool IsAccountTypeExists(int acc_type);

        public bool IsOwnershipTypeExists(int ownership_type);

        public bool IsCurrencyTypeExists(int currency_type);

        public bool IsCoditionTypeExists(int codition_type);

        public bool IsBotTypeExists(int bot_type);

        #endregion


    }
}
