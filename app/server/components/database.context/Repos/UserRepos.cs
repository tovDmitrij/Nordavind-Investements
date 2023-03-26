using database.context.Models;
namespace database.context.Repos
{
    public class UserRepos : IUserRepos
    {
        private readonly DataContext _db;

        public UserRepos(DataContext db) => _db = db;

        public void Add(string email, string password, string surname, string name, string? patronymic)
        {
            _db.Users.Add(new(surname, name, patronymic, email, password));
            _db.SaveChanges();
        }

        public UserModel? GetByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => 
                u.Email == email);
        }

        public UserModel? GetByEmailAndPassword(string email, string password)
        {
            return _db.Users.FirstOrDefault(u => 
                u.Email == email && u.Password == password);
        }

        public UserModel? GetByID(int id)
        {
            return _db.Users.FirstOrDefault(u => 
                u.ID == id);
        }
    }
}