namespace BE.Models;

public enum Role {
        User,
        Super,
        Admin
}

public class User
{
    public Guid Sid { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
    public Guid[]? Follows { get; set; }
}
