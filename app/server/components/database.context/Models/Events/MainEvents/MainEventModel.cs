using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Events.MainEvents
{
    /// <summary>
    /// Базовая информация о пользователе в системе
    /// </summary>
    [Table("main_events")]
    public sealed class MainEventModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Required]
        [Column("hold_interest")]
        public bool HoldInterest { get; set; }

        [Required]
        [Column("link")]
        public string Link { get; set; }



        public MainEventModel(int id, int accountId, bool hold_interest, string link) : this(accountId, hold_interest, link)
        {
            ID = id;
        }

        public MainEventModel(int accountId, bool hold_interest, string link)
        {
            AccountId = accountId;
            HoldInterest = hold_interest;
            Link = link;
        }

        public MainEventModel() { }

    }
}
