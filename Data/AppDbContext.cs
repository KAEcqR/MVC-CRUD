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
        new Event { Id = 2, Title = "Tech Expo", Artist = "John Smith", Date = new DateOnly(2024, 5, 15), VenueId = 2, ImagePath = "techexpo.jpg", TotalTickets = 1000, TicketsLeft = 1000},
        new Event { Id = 3, Title = "Art Show", Artist = "Alice Lee", Date = new DateOnly(2025, 11, 20), VenueId = 3, ImagePath = "artshow.jpg", TotalTickets = 300, TicketsLeft = 300},
        new Event { Id = 4, Title = "Jazz Night", Artist = "Miles Davis Tribute", Date = new DateOnly(2026, 3, 15), VenueId = 1, ImagePath = "jazznight.jpg", TotalTickets = 400, TicketsLeft = 380},
        new Event { Id = 5, Title = "Rock Concert", Artist = "The Rolling Stones Covers", Date = new DateOnly(2026, 4, 10), VenueId = 2, ImagePath = "rockconcert.jpg", TotalTickets = 800, TicketsLeft = 650},
        new Event { Id = 6, Title = "Tech Conference 2026", Artist = "Industry Leaders Panel", Date = new DateOnly(2026, 5, 22), VenueId = 3, ImagePath = "techconf.jpg", TotalTickets = 250, TicketsLeft = 120},
        new Event { Id = 7, Title = "Comedy Night", Artist = "Stand-up Comics Showcase", Date = new DateOnly(2026, 6, 5), VenueId = 1, ImagePath = "comedy.jpg", TotalTickets = 350, TicketsLeft = 200},
        new Event { Id = 8, Title = "Classical Symphony", Artist = "Philharmonic Orchestra", Date = new DateOnly(2026, 7, 12), VenueId = 2, ImagePath = "symphony.jpg", TotalTickets = 900, TicketsLeft = 900},
        new Event { Id = 9, Title = "Film Festival Opening", Artist = "International Cinema", Date = new DateOnly(2026, 8, 1), VenueId = 3, ImagePath = "filmfest.jpg", TotalTickets = 280, TicketsLeft = 180},
        new Event { Id = 10, Title = "Dance Spectacular", Artist = "Contemporary Dance Ensemble", Date = new DateOnly(2026, 9, 18), VenueId = 1, ImagePath = "dance.jpg", TotalTickets = 450, TicketsLeft = 350}
    );
}
}
