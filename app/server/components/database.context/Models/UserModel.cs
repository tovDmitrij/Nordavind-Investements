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

        public UserModel(int id, string email, string password, DateTime date) : this(email, password)
        {
            ID = id;
            RegistrationDate = date;
        }

        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserModel() { }
    }
}