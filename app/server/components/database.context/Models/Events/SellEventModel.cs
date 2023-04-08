using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events
{
    /// <summary>
    /// Базовая информация о пользователе в системе
    /// </summary>
    [Table("sell_events")]
    public sealed class SellEventModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Required]
        [Column("bot_type")]
        public int BotType { get; set; }

        public SellEventModel(int id, int accountId, int botType) : this(accountId, botType)
        {
            ID = id;
        }

        public SellEventModel(int accountId, int botType)
        {
            AccountId = accountId;
            BotType = botType;
        }

        public SellEventModel() { }
    }
}
