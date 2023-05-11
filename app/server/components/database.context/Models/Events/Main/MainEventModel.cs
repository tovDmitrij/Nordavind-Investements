using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.Main
{
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

        public MainEventModel(int id, int accountId, bool hold_interest)
        {
            ID = id;
            AccountId = accountId;
            HoldInterest = hold_interest;
        }

        public MainEventModel() { }
    }
}