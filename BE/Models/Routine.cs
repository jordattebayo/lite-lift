﻿using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Routine
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Notes { get; set; }

    public Guid? StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();

    public virtual Status? Status { get; set; }

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
