using database.context.Models;
using misc.security;
namespace database.context.Repos
{
    public sealed class UserRepos : IUserRepos
    {
        private readonly DataContext _db;

        public UserRepos(DataContext db) => _db = db;

        public bool IsEmailBusy(string email) => _db.TableUsers
            .Any(u => u.Email == email);

        public bool IsUserExist(string email, string password) => _db.TableUsers
            .Any(user => user.Email == email && user.Password == Security.HashPassword(email, password));

        public void Add(string email, string password)
        {
            _db.TableUsers.Add(new(
                email, 
                Security.HashPassword(email,password)));
            _db.SaveChanges();
        }

        public UserModel? GetUserInfo(string email, string password) => _db.TableUsers
            .FirstOrDefault(u => 
                u.Email == email && u.Password == Security.HashPassword(email, password));
    }
}