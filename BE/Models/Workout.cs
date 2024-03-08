using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BE.Models;

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


