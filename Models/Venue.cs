using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models;

public class Venue
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Location { get; set; }
    [Required]
    public int? Capacity { get; set; }
    [Required]
    public string? Description { get; set; }
    public ICollection<Event>? Events { get; set; }
}
