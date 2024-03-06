using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BE.Models;

public enum Unit 
{
    Lbs,
    Kilos,
}

public class Set
{
    [Key]
    public long Id { get; set; }
    public Guid Sid { get; set; }
    public int Weight { get; set; }
    public Unit Unit { get; set; }
    public int Reps { get; set; }
    public int Order { get; set; }
    public Guid WorkoutId { get; set; }
    public string? Category { get; set; }
    public string? Group { get; set; }
}

public class Workout
{
    [Key]
    public long Id { get; set; }
    public Guid Sid { get; set; }
    public string? Notes { get; set; }
    public Guid UserId { get; set; }
    public Guid? GroupId { get; set; }
    public DateTime Date { get; set; }
}

public enum Status
{
    Draft,
    Active,
    Inactive
}

public class Routine
{
    [Key]
    public long Id { get; set; }
    public Guid Sid { get; set; }
    public string? Name { get; set; }
    public string? Notes { get; set; }
    public Status Status { get; set; }
}