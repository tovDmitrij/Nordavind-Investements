using Microsoft.EntityFrameworkCore;
using database.context.Models;
namespace database.context
{
    /// <summary>
    /// Контекст базы данных инвестиций
    /// </summary>
    public sealed class DataContext: DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}