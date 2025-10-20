using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models;

public class Ticket
{
    public int Id { get; set; }
    [Required]
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    public double Price { get; set; }
    public int EventId { get; set; }
    [Required]
    public string UserId { get; set; } = string.Empty;
    [ForeignKey("UserId")]
    public ApplicationUser? User { get; set; }
}
