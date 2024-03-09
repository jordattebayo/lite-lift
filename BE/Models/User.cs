using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public Guid? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Follow> FollowFollowedUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowingUsers { get; set; } = new List<Follow>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
