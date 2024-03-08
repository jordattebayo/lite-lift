using System.ComponentModel.DataAnnotations;

namespace BE.Models
{
    public enum Unit
    {
        Lbs,
        Kilos,
    }

    public class Set
    {
        [Key]
        public long Id { get; set; }
        public Guid Sid { get; set; }
        public int Weight { get; set; }
        public Guid UnitId { get; set; }
        public int Reps { get; set; }
        public int Order { get; set; }
        public Guid WorkoutId { get; set; }
        public string? CategoryId { get; set; }
        public string? GroupId { get; set; }

    }
}
