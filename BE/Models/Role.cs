using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
