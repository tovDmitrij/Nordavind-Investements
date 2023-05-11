using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.Main
{
    [Keyless]
    [Table("view_history_main_events")]
    public sealed class HistoryMainEventModel
    {
        [Required]
        [Column("event_id")]
        public int ID { get; set; }

        [Required]
        [Column("investor")]
        public string Investor { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("op_title")]
        public string OperationTitle { get; set; }

        [Required]
        [Column("value")]
        public decimal Value { get; set; }

        [Required]
        [Column("A/C No")]
        public int AccountId { get; set; }

        public HistoryMainEventModel(int event_id, string investor, DateTime date, string op_title, decimal value, int accountId)
        {
            ID = event_id;
            Investor = investor;
            Date = date;
            OperationTitle = op_title;
            Value = value;
            AccountId = accountId;
        }

        public HistoryMainEventModel() { }
    }
}