using database.context.Models.Events.Flip;
using database.context.Models.Events.Main;
using database.context.Models.Events.Pay;
using database.context.Models.Events.Sell;

namespace database.context.Repos.Event
{
    public interface IEventRepos
    {


        public IEnumerable<HistoryMainEventModel> GetMainEvents();

        public IEnumerable<HistoryFlipEventModel> GetFlipEvents();

        public IEnumerable<HistoryPayEventModel> GetPayEvents();

        public IEnumerable<HistorySellEventModel> GetSellEvents();

        public IEnumerable<HistoryMainEventModel> GetMainEvents(int acc_id);

        public IEnumerable<HistoryFlipEventModel> GetFlipEvents(int acc_id);

        public IEnumerable<HistorySellEventModel> GetSellEvents(int acc_id);

        public void AddMainEvent(int operationId, decimal value, DateTime date, int accountId, bool hold_interest, string link);

        public void AddFlipEvent(int operationId, decimal value, DateTime date, int account_from, int account_to, int fund_type);

        public void AddPayEvent(int operationId, decimal value, DateTime date, string link);

        public void AddSellEvent(int operationId, decimal value, DateTime date, int accountId, int botType);


        public void UpdateMainEvent(int mainEventId, int accountId, bool hold_interest, string link);

        public void UpdateFlipEvent(int flipEventId, int account_from, int account_to, int fund_type);

        public void UpdatePayEvent(int payEventId, string link);

        public void UpdateSellEvent(int sellEventId, int accountId, int botType);


        public void DeleteMainEvent(int mainEventId);

        public void DeleteFlipEvent(int flipEventId);

        public void DeletePayEvent(int payEventId);

        public void DeleteSellEvent(int sellEventId);

        public bool IsEventExists(int eventId);

        public bool IsAccountIdExists(int acc_id);

        public bool IsFundIdExists(int fund_id);

        public bool IsOperationExists(int op_id);

        public bool IsBotTypeExists(int bot_type);
    }
}
