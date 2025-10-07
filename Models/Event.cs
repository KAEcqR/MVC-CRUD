using System;

namespace MVC_CRUD.Models;

public class Event
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public int Year { get; set; }
    public DateOnly Date { get; set; }
    public int VenueId { get; set; }
    public string? ImagePath { get; set; }
}
