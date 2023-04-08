using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Data
{
    /// <summary>
    /// Базовая информация о пользователе в системе
    /// </summary>
    [Table("conditions")]
    public sealed class ConditionModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("value")]
        public decimal Value { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        public ConditionModel(int id, string title, decimal value, string description)
        {
            ID = id;
            Title = title;
            Value = value;
            Description = description;

        }

        public ConditionModel(string title, decimal value, string description)
        {
            Title = title;
            Value = value;
            Description = description;
        }

        public ConditionModel() { }

    }
}
