using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Data
{
    [Table("funds")]
    public sealed class FundModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        public FundModel(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }
        public FundModel()
        {
            
        }
    }
}
