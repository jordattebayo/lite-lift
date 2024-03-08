using System.ComponentModel.DataAnnotations;

namespace BE.Models
{
    public enum Status
    {
        Draft,
        Active,
        Inactive
    }
    public class Routine
    {
        [Key]
        public long Id { get; set; }
        public Guid Sid { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public Status StatusId { get; set; }
    }
}
