using System;

namespace MVC_CRUD.Models;

public class Venue
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public int? Capacity { get; set; }
    public string? Description { get; set; }
    public ICollection<Event>? Events { get; set; }
}
