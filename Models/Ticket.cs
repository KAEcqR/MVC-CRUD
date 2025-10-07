using System;

namespace MVC_CRUD.Models;

public class Ticket
{
    public int Id { get; set; }
    public double Price { get; set; }
    public int EventId { get; set; }
    public int UserId { get; set; }
}
