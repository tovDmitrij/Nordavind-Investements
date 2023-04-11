using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.Flip
{
    [Table("flip_events")]
    public sealed class FlipEventModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("account_from")]
        public int AccountFrom { get; set; }

        [Required]
        [Column("account_to")]
        public int AccountTo { get; set; }

        [Required]
        [Column("fund_type")]
        public int FundType { get; set; }

        public FlipEventModel(int id, int account_from, int account_to, int fund_type) : this(account_from, account_to, fund_type)
        {
            ID = id;
        }

        public FlipEventModel(int account_from, int account_to, int fund_type)
        {
            AccountFrom = account_from;
            AccountTo = account_to;
            FundType = fund_type;
        }

        public FlipEventModel()
        {

        }
    }
}
