using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BE.Models;

public enum Role {
        User,
        Super,
        Admin
}

public class User
{
    [Key]
    public long Id { get; set; }
    public Guid Sid { get; set; }
    [StringLength(25)]
    public string? Username { get; set; }
    [StringLength(5)]
    public string? Role { get; set; }
    public string[]? Follows { get; set; }
}
