using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Set
{
    public Guid Id { get; set; }

    public int Weight { get; set; }

    public Guid? UnitId { get; set; }

    public int Reps { get; set; }

    public int? Order { get; set; }

    public Guid? WorkoutId { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? RoutineId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Routine? Routine { get; set; }

    public virtual Unit? Unit { get; set; }

    public virtual Workout? Workout { get; set; }
}
