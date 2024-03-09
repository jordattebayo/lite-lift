using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Workout
{
    public Guid Id { get; set; }

    public string? Notes { get; set; }

    public Guid? UserId { get; set; }

    public Guid? RoutineId { get; set; }

    public DateTime Date { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Routine? Routine { get; set; }

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();

    public virtual User? User { get; set; }
}
