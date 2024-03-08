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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public long Id { get; set; }
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Sid { get; set; }
    [StringLength(25)]
    public string? Username { get; set; }
    public Guid? RoleId { get; set; }
}
