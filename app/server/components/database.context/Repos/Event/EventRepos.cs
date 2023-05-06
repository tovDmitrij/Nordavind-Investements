using database.context.Models.Data;
using database.context.Models.Events.Flip;
using database.context.Models.Events.Main;
using database.context.Models.Events.Pay;
using database.context.Models.Events.Sell;
using Microsoft.Extensions.Logging;
using misc.security;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace database.context.Repos.Event
{
    public sealed class EventRepos : IEventRepos
    {

        private readonly DataContext _db;

        public EventRepos(DataContext db) => _db = db;

        private void AddEvent(int operation_type, decimal value, string description, DateTime date)
        {
            _db.TableEvents.Add(new(operation_type, value, description, date));
            _db.SaveChanges();
        }

        public void AddFlipEvent(int operationId, decimal value, DateTime date, int account_from, int account_to, int fund_type)
        {
            AddEvent(operationId, value, string.Empty, date);
            _db.TableFlipEvents.Add(new(account_from, account_to, fund_type));
            _db.SaveChanges();
        }

        public void AddMainEvent(int operationId, decimal value, DateTime date, int accountId, bool hold_interest, string link)
        {
            AddEvent(operationId, value, string.Empty, date);
            _db.TableMainEvents.Add(new(accountId, hold_interest, link));
            _db.SaveChanges();
        }

        public void AddPayEvent(int operationId, decimal value, DateTime date, string link)
        {
            AddEvent(operationId, value, string.Empty, date);
            _db.TablePayEvents.Add(new(link));
            _db.SaveChanges();
        }

        public void AddSellEvent(int operationId, decimal value, DateTime date, int accountId, int botType)
        {
            AddEvent(operationId, value, string.Empty, date);
            _db.TableSellEvents.Add(new(accountId, botType));
            _db.SaveChanges();
        }

        private void DeleteEvent(int eventId)
        {
            var e = _db.TableEvents.Single(e => e.ID == eventId);
            _db.TableEvents.Remove(e);
            _db.SaveChanges();
        }

        public void DeleteFlipEvent(int flipEventId)
        {
            var e = _db.TableFlipEvents.Single(e => e.ID == flipEventId);
            _db.TableFlipEvents.Remove(e);
            _db.SaveChanges();
            DeleteEvent(flipEventId);
        }

        public void DeleteMainEvent(int mainEventId)
        {
            var e = _db.TableMainEvents.Single(e => e.ID == mainEventId);
            _db.TableMainEvents.Remove(e);
            _db.SaveChanges();
            DeleteEvent(mainEventId);
        }

        public void DeletePayEvent(int payEventId)
        {
            var e = _db.TablePayEvents.Single(e => e.ID == payEventId);
            _db.TablePayEvents.Remove(e);
            _db.SaveChanges();
            DeleteEvent(payEventId);
        }

        public void DeleteSellEvent(int sellEventId)
        {
            var e = _db.TableSellEvents.Single(e => e.ID == sellEventId);
            _db.TableSellEvents.Remove(e);
            _db.SaveChanges();
            DeleteEvent(sellEventId);
        }

        public bool IsEventExists(int eventId) => _db.TableEvents.Any(e => e.ID == eventId);

        public void UpdateEvent(int eventId, int operation_type, decimal value, string description, DateTime date)
        {
            var e = _db.TableEvents.Single(e => e.ID == eventId);
            e.OperationType = operation_type;
            e.Value = value;
            e.Description = description;
            e.Date = date;
            _db.TableEvents.Update(e);
            _db.SaveChanges();
        }

        public void UpdateFlipEvent(int flipEventId, int account_from, int account_to, int fund_type)
        {
            var e = _db.TableFlipEvents.Single(e => e.ID == flipEventId);
            e.AccountFrom = account_from;
            e.AccountTo = account_to;
            e.FundType = fund_type;
            _db.TableFlipEvents.Update(e);
            _db.SaveChanges();
        }

        public void UpdateMainEvent(int mainEventId, int accountId, bool hold_interest, string link)
        {
            var e = _db.TableMainEvents.Single(e => e.ID == mainEventId);
            e.AccountId = accountId;
            e.HoldInterest = hold_interest;
            e.Link = link;
            _db.TableMainEvents.Update(e);
            _db.SaveChanges();
        }

        public void UpdatePayEvent(int payEventId, string link)
        {
            var e = _db.TablePayEvents.Single(e => e.ID == payEventId);
            e.Link = link;
            _db.TablePayEvents.Update(e);
            _db.SaveChanges();
        }

        public void UpdateSellEvent(int sellEventId, int accountId, int botType)
        {
            var e = _db.TableSellEvents.Single(e => e.ID == sellEventId);
            e.AccountId = accountId;
            e.BotType = botType;
            _db.TableSellEvents.Update(e);
            _db.SaveChanges();
        }

        public IEnumerable<HistoryMainEventModel> GetMainEvents() => _db.TableHistoryMainEvents.ToList();
        public IEnumerable<HistoryFlipEventModel> GetFlipEvents() => _db.TableHistoryFlipEvents.ToList();

        public IEnumerable<HistoryPayEventModel> GetPayEvents() => _db.TableHistoryPayEvents.ToList();

        public IEnumerable<HistorySellEventModel> GetSellEvents() => _db.TableHistorySellEvents.ToList();

        public IEnumerable<HistoryMainEventModel> GetMainEvents(int acc_id) => _db.TableHistoryMainEvents
            .Where(e => e.AccountId == acc_id).ToList();

        public IEnumerable<HistoryFlipEventModel> GetFlipEvents(int acc_id) => _db.TableHistoryFlipEvents
            .Where(e => e.AccountFrom == acc_id || e.AccountTo == acc_id).ToList();

        public IEnumerable<HistorySellEventModel> GetSellEvents(int acc_id) => _db.TableHistorySellEvents
            .Where(e => e.AccountId == acc_id).ToList();

        public bool IsAccountIdExists(int acc_id) => _db.TableAccounts.Any(acc => acc.ID == acc_id);

        public bool IsFundIdExists(int fund_id) => _db.TableFunds.Any(fund => fund.ID == fund_id);

        public bool IsOperationExists(int op_id) => _db.TableOperations.Any(operation => operation.ID == op_id);

        public bool IsBotTypeExists(int bot_type) => _db.TableBotTypes.Any(botType => botType.ID == bot_type);
    }
}
