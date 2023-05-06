using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.Pay
{
    /// <summary>
    /// Базовая информация о пользователе в системе
    /// </summary>

    [Table("pay_events")]
    public sealed class PayEventModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("link")]
        public string Link { get; set; }

        public PayEventModel(int id, string link) : this(link)
        {
            ID = id;
        }

        public PayEventModel(string link)
        {
            Link = link;
        }

        public PayEventModel()
        {

        }
    }
}
