using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Data
{
    [Table("accounts")]
    public sealed class AccountModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("type")]
        public int Type { get; set; }

        [Required]
        [Column("currency_type")]
        public int CurrencyType { get; set; }

        [Required]
        [Column("condition_type")]
        public int ConditionType { get; set; }

        [Required]
        [Column("ownership_type")]
        public int OwnerShipType { get; set; }

        [Required]
        [Column("bot_type")]
        public int BotType { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        public AccountModel(int id, int type, int currency_type, int condition_type, int ownership_type, int bot_type, string title, DateTime date) : this(type, currency_type, condition_type, ownership_type,bot_type, title, date)
        {
            ID = id;
        }
        public AccountModel(int type, int currency_type, int condition_type, int ownership_type, int bot_type, string title, DateTime date)
        {
            Type = type;
            CurrencyType = currency_type;
            ConditionType = condition_type;
            OwnerShipType = ownership_type;
            BotType = bot_type;
            Title = title;
            Date = date;
        }
        public AccountModel() { }

    }
}
