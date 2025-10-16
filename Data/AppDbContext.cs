using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;

namespace MVC_CRUD.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<Venue> Venues { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=mvc-tickets;user=root;password=;",
                ServerVersion.AutoDetect("server=localhost;database=mvc-tickets;user=root;password=;")
            );
        }
    }
        
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Venues
    modelBuilder.Entity<Venue>().HasData(
        new Venue { Id = 1, Name = "Grand Hall", Location = "Downtown", Capacity = 500, Description = "A large venue for concerts and events."},
        new Venue { Id = 2, Name = "Open Arena", Location = "Uptown", Capacity = 1000, Description = "An outdoor arena for sports and large gatherings."}, 
        new Venue { Id = 3, Name = "Conference Center", Location = "Midtown", Capacity = 300, Description = "A modern venue for conferences and meetings."}
    );

    // Events
    modelBuilder.Entity<Event>().HasData(
        new Event { Id = 1, Title = "Music Fest", Artist = "Jane Doe", Date = new DateOnly(2023, 8, 1), VenueId = 1, ImagePath = "musicfest.jpg", TotalTickets = 500, TicketsLeft = 500},
        new Event { Id = 2, Title = "Tech Expo", Artist = "John Smith", Date = new DateOnly(2024, 5, 15), VenueId = 2, ImagePath = "musicfest.jpg", TotalTickets = 1000, TicketsLeft = 1000},
        new Event { Id = 3, Title = "Art Show", Artist = "Alice Lee", Date = new DateOnly(2025, 11, 20) , VenueId = 3, ImagePath = "musicfest.jpg", TotalTickets = 300, TicketsLeft = 300}
    );

    // Tickets
    modelBuilder.Entity<Ticket>().HasData(
        new Ticket { Id = 1, Price = 50, EventId = 1, UserId = 1 },
        new Ticket { Id = 2, Price = 75.0, EventId = 2, UserId = 2 },
        new Ticket { Id = 3, Price = 100.0, EventId = 3, UserId = 3 }
    );
}
}
