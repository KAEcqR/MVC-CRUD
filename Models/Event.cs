using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models;

public class Event
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Artist is required")]
    public string? Artist { get; set; }
    [Required(ErrorMessage = "Date is required")]
    public DateOnly Date { get; set; }
    [Required(ErrorMessage = "Venue is required")]
    public int VenueId { get; set; }
    public Venue? Venue { get; set; }
    public string? ImagePath { get; set; }
}
