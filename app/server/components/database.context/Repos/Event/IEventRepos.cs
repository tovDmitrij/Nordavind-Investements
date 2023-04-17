using database.context.Models.Events.FlipEvents;
using database.context.Models.Events.MainEvents;
using database.context.Models.Events.PayEvents;
using database.context.Models.Events.SellEvents;
namespace database.context.Repos.Event
{
    public interface IEventRepos
    {


        #region Add-методы для добавления событий в БД

        public void AddMainEvent(int operationId, decimal value, DateTime date, int accountId, bool hold_interest, string link);

        public void AddFlipEvent(int operationId, decimal value, DateTime date, int account_from, int account_to, int fund_type);

        public void AddPayEvent(int operationId, decimal value, DateTime date, string link);

        public void AddSellEvent(int operationId, decimal value, DateTime date, int accountId, int botType);

        #endregion


        #region Get-методы для вывода событий

        public IEnumerable<HistoryMainEventModel> GetMainEvents();

        public IEnumerable<HistoryFlipEventModel> GetFlipEvents();

        public IEnumerable<HistoryPayEventModel> GetPayEvents();

        public IEnumerable<HistorySellEventModel> GetSellEvents();

        public IEnumerable<HistoryMainEventModel> GetMainEvents(int acc_id);

        public IEnumerable<HistoryFlipEventModel> GetFlipEvents(int acc_id);

        public IEnumerable<HistorySellEventModel> GetSellEvents(int acc_id);

        #endregion


        #region Update-методы для обновления событий в БД

        public void UpdateMainEvent(int mainEventId, int accountId, bool hold_interest, string link);

        public void UpdateFlipEvent(int flipEventId, int account_from, int account_to, int fund_type);

        public void UpdatePayEvent(int payEventId, string link);

        public void UpdateSellEvent(int sellEventId, int accountId, int botType);

        #endregion


        #region Delete-методы для удаления событий из БД

        public void DeleteMainEvent(int mainEventId);

        public void DeleteFlipEvent(int flipEventId);

        public void DeletePayEvent(int payEventId);

        public void DeleteSellEvent(int sellEventId);

        #endregion


        #region Проверка существования данных в таблицах

        public bool IsEventExists(int eventId);

        public bool IsAccountIdExists(int acc_id);

        public bool IsFundIdExists(int fund_id);

        public bool IsOperationExists(int op_id);

        public bool IsBotTypeExists(int bot_type);

        #endregion


    }
}
