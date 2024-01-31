namespace BE.Models;

public enum Unit 
{
    Lbs,
    Kilos,
}

public class Set
{
    public Guid Sid { get; set; }
    public int Weight { get; set; }
    public Unit Unit { get; set; }
    public int Reps { get; set; }
    public int Order { get; set; }
    public Guid WorkoutId { get; set; }
    public string Category { get; set; }
    public string? Group { get; set; }
}

public class Workout
{
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
    public Guid Sid { get; set; }
    public string? Name { get; set; }
    public string? Notes { get; set; }
    public Status Status { get; set; }
}