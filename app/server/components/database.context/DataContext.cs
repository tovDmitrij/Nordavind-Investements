using Microsoft.EntityFrameworkCore;
using database.context.Models;
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

        public DataContext(DbContextOptions options) : base(options) { }
    }
}