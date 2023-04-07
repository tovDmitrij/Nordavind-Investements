using database.context.Models;
namespace database.context.Repos
{
    /// <summary>
    /// Взаимодействие с таблицей пользователей в базе данных
    /// </summary>
    public interface IUserRepos
    {
        /// <summary>
        /// Метод, проверяющий существование пользователя в системе по его почте и паролю
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public bool IsUserExist(string email, string password);

        /// <summary>
        /// Метод, проверяющий занята ли кем-то введённая почта
        /// </summary>
        /// <param name="email"></param>
        public bool IsEmailBusy(string email);

        /// <summary>
        /// Добавить нового пользователя в систему
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public void Add(string email, string password);

        /// <summary>
        /// Получить базовую информацию о пользователе по его почте и паролю
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserModel? GetUserInfo(string email, string password);
    }
}