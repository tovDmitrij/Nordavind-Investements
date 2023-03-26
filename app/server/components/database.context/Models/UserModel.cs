using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models
{
    [Table("users")]
    public sealed class UserModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("patronymic")]
        public string? Patronymic { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("date")]
        public DateTime RegistrationDate { get; set; }

        public UserModel(int id, string surname, string name, string? patronymic, string email, string password, DateTime date)
        {
            ID = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Email = email;
            Password = password;
            RegistrationDate = date;
        }

        public UserModel(string surname, string name, string patronymic, string email, string password)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Email = email;
            Password = password;
        }

        public UserModel() { }
    }
}