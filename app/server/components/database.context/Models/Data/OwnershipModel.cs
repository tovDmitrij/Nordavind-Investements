using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace database.context.Models.Data
{
    [Table("ownerships")]
    public sealed class OwnershipModel
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

        public OwnershipModel(int id, string title, string description) : this(title,description)
        {
            ID = id;
        }

        public OwnershipModel(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public OwnershipModel() { }
    }
}
