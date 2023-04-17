using Microsoft.EntityFrameworkCore;
using database.context.Models;
using database.context.Models.Data;
using database.context.Models.Events;
using database.context.Models.Events.MainEvents;
using database.context.Models.Events.FlipEvents;
using database.context.Models.Events.PayEvents;
using database.context.Models.Events.SellEvents;
using database.context.Models.Data.Account;

namespace database.context
{
    /// <summary>
    /// Контекст базы данных инвестиций
    /// </summary>
    public sealed class DataContext: DbContext
    {
        /// <summary>
        /// Таблица с пользователями
        /// </summary>
        public DbSet<UserModel> TableUsers { get; set; }

        public DbSet<ConditionModel> TableConditions { get; set; }

        public DbSet<CurrencyModel> TableCurrencies { get; set; }

        public DbSet<AccountTypeModel> TableAccountTypes { get; set; }

        public DbSet<BotTypeModel> TableBotTypes { get; set; }

        public DbSet<OperationModel> TableOperations { get; set; }

        public DbSet<FundModel> TableFunds { get; set; }

        public DbSet<EventModel> TableEvents { get; set; }

        public DbSet<MainEventModel> TableMainEvents { get; set; }

        public DbSet<FlipEventModel> TableFlipEvents { get; set; }

        public DbSet<SellEventModel> TableSellEvents { get; set; }

        public DbSet<PayEventModel> TablePayEvents { get; set; }

        public DbSet<HistoryMainEventModel> TableHistoryMainEvents { get; set; }

        public DbSet<HistoryFlipEventModel> TableHistoryFlipEvents { get; set; }

        public DbSet<HistoryPayEventModel> TableHistoryPayEvents { get; set; }

        public DbSet<HistorySellEventModel> TableHistorySellEvents { get; set; }

        public DbSet<AccountModel> TableAccounts { get; set; }

        public DbSet<OwnershipModel> TableOwnerships { get; set; }

        public DbSet<AccountDetailModel> TableAccountDetails { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

    }
}