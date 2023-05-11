using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.Pay
{
    [Keyless]
    [Table("view_history_pay_events")]
    public sealed class HistoryPayEventModel
    {
        [Required]
        [Column("event_id")]
        public int ID { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("op_id")]
        public int OperationId { get; set; }

        [Required]
        [Column("op_title")]
        public string OperationTitle { get; set; }

        [Required]
        [Column("value")]
        public decimal Value { get; set; }

        [Required]
        [Column("link")]
        public string Link { get; set; }

        public HistoryPayEventModel(int event_id, DateTime date, int op_id, string op_title, decimal value, string link)
        {
            ID = event_id;
            Date = date;
            OperationId = op_id;
            OperationTitle = op_title;
            Value = value;
            Link = link;
        }

        public HistoryPayEventModel() { }
    }
}
