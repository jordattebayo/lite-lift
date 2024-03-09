using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Status
{
    public Guid Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
