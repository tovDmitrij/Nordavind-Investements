using Microsoft.EntityFrameworkCore;
using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.SellEvents
{
    [Keyless]
    [Table("view_history_sell_events")]
    public sealed class HistorySellEventModel
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
        [Column("account_id")]
        public int AccountId { get; set; }

        [Required]
        [Column("value")]
        public decimal Value { get; set; }

        [Required]
        [Column("bot_id")]
        public int BotId { get; set; }


        [Required]
        [Column("bot_title")]
        public string BotTitle { get; set; }

        public HistorySellEventModel(int event_id, DateTime date, int op_id, string op_title, int accountId, decimal value, int bot_id, string bot_title)
        {
            ID = event_id;
            Date = date;
            OperationId = op_id;
            OperationTitle = op_title;
            AccountId = accountId;
            Value = value;
            BotId = bot_id;
            BotTitle = bot_title;
        }

        public HistorySellEventModel() { }
    }
}
