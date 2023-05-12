using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data.Account
{
    [Keyless]
    [Table("view_account_details")]
    public sealed class AccountDetailModel
    {
        [Required]
        [Column("A/C No")]
        public int AccountId { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }

        [Required]
        [Column("ownership")]
        public string Ownership { get; set; }

        [Required]
        [Column("currency")]
        public string Currency { get; set; }

        [Required]
        [Column("condition")]
        public string Condition { get; set; }

        [Required]
        [Column("bot")]
        public string Bot { get; set; }

        [Required]
        [Column("value")]
        public decimal Value { get; set; }

        [Required]
        [Column("percents")]
        public decimal Percents { get; set; }

        public AccountDetailModel(int acc_id, string title, string type, string ownership, string currency, string condition, string bot, decimal value, decimal percents)
        {
            AccountId = acc_id;
            Title = title;
            Type = type;
            Ownership = ownership;
            Currency = currency;
            Condition = condition;
            Bot = bot;
            Value = value;
            Percents = percents;
        }

        public AccountDetailModel() { }
    }
}