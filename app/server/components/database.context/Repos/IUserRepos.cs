using database.context.Models;
namespace database.context.Repos
{
    /// <summary>
    /// Взаимодействие с таблицей пользователей в базе данных
    /// </summary>
    public interface IUserRepos
    {
        public void Add(string email, string password, string surname, string name, string? patronymic);

        public UserModel? GetByID(int id);

        public UserModel? GetByEmail(string email);

        public UserModel? GetByEmailAndPassword(string email, string password);
    }
}