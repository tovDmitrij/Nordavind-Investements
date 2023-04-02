using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models
{
    /// <summary>
    /// Базовая информация о пользователе в системе
    /// </summary>
    [Table("users")]
    public sealed class UserModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required]
        [Column("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        [Column("patronymic")]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        [Required]
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        [Required]
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