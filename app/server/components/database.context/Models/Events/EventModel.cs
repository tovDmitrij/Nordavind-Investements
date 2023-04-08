using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.context.Models.Events
{
    /// <summary>
    /// Базовая информация о пользователе в системе
    /// </summary>
    [Table("events")]
    public sealed class EventModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("operation_type")]
        public int OperationType { get; set; }

        [Required]
        [Column("value")]
        public decimal Value { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        public EventModel(int id, int operation_type, decimal value, string description, DateTime date) : this(operation_type, value, description, date)
        {
            ID = id;
        }

        public EventModel(int operation_type, decimal value, string description, DateTime date)
        {
            OperationType = operation_type;
            Value = value;
            Description = description;
            Date = date;
        }
    }
}
