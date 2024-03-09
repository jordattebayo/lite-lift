using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Unit
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
