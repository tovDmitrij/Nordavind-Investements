using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Data
{
    [Table("trade_bots")]
    public sealed class BotTypeModel
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

        public BotTypeModel(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }

        public BotTypeModel(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public BotTypeModel() { }

    }
}
