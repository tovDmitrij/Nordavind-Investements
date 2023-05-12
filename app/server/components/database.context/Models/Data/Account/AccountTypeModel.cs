using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data.Account
{
    [Table("account_types")]
    public sealed class AccountTypeModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        public AccountTypeModel(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }

        public AccountTypeModel(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public AccountTypeModel() { }

    }
}
