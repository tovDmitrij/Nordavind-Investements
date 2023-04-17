using Microsoft.EntityFrameworkCore;
using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.FlipEvents
{
    [Keyless]
    [Table("view_history_flip_events")]
    public sealed class HistoryFlipEventModel
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
        [Column("A/C X")]
        public int AccountFrom { get; set; }

        [Required]
        [Column("A/C Y")]
        public int AccountTo { get; set; }

        public HistoryFlipEventModel(int event_id, DateTime date, int op_id, string op_title, decimal value, int account_from, int account_to)
        {
            ID = event_id;
            Date = date;
            OperationId = op_id;
            OperationTitle = op_title;
            Value = value;
            AccountFrom = account_from;
            AccountTo = account_to;
        }

        public HistoryFlipEventModel() { }

    }
}
