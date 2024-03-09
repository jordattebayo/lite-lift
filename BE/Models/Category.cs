using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Category
{
    public Guid Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
}
