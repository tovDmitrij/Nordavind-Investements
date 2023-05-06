using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Data
{
    [Table("currencies")]
    public sealed class CurrencyModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("short_title")]
        public string ShortTitle { get; set; }

        public CurrencyModel(int id, string title, string short_title)
        {
            ID = id;
            Title = title;
            ShortTitle = short_title;
        }

        public CurrencyModel(string title, string short_title)
        {
            Title = title;
            ShortTitle = short_title;
        }

        public CurrencyModel() { }

    }
}
