using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Events.Pay
{
    [Table("pay_events")]
    public sealed class PayEventModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("link")]
        public string Link { get; set; }

        public PayEventModel(int id, string link)
        {
            ID = id;
            Link = link;
        }

        public PayEventModel() {  }
    }
}
