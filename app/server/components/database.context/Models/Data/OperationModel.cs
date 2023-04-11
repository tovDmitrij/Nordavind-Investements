using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.context.Models.Data
{
    [Table("operations")]
    public sealed class OperationModel
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

        public OperationModel(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }
        public OperationModel()
        {
            
        }
    }
}
