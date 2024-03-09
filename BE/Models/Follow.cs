using System;
using System.Collections.Generic;

namespace BE.Models;

public partial class Follow
{
    public long Id { get; set; }

    public Guid? FollowingUserId { get; set; }

    public Guid? FollowedUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? FollowedUser { get; set; }

    public virtual User? FollowingUser { get; set; }
}
