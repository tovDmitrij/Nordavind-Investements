using Microsoft.EntityFrameworkCore;
using database.context.Models;
using database.context.Models.Data;

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

        public DataContext(DbContextOptions options) : base(options) { }
    }
}