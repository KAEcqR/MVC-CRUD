using System;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;

namespace MVC_CRUD.Data;

public class AppDbContext : DbContext
{

    public DbSet<Venue> Venues { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }

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
        new Venue { Id = 1, Name = "Grand Hall", Location = "Downtown" },
        new Venue { Id = 2, Name = "Open Arena", Location = "Uptown" },
        new Venue { Id = 3, Name = "Conference Center", Location = "Midtown" }
    );

    // Events
    modelBuilder.Entity<Event>().HasData(
        new Event { Id = 1, Title = "Music Fest", Artist = "Jane Doe", Year = 2023, Date = new DateOnly(2023, 8, 1), VenueId = 1 },
        new Event { Id = 2, Title = "Tech Expo", Artist = "John Smith", Year = 2024, Date = new DateOnly(2024, 5, 15), VenueId = 2 },
        new Event { Id = 3, Title = "Art Show", Artist = "Alice Lee", Year = 2025, Date = new DateOnly(2025, 11, 20) , VenueId = 3 }
    );

    // Users
    modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "Alice", Surname = "Johnson", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Surname = "Smith", Email = "bob@example.com" },
        new User { Id = 3, Name = "Charlie", Surname = "Brown", Email = "charlie@example.com" }
    );

    // Tickets
    modelBuilder.Entity<Ticket>().HasData(
        new Ticket { Id = 1, Price = 50, EventId = 1, UserId = 1 },
        new Ticket { Id = 2, Price = 75.0, EventId = 2, UserId = 2 },
        new Ticket { Id = 3, Price = 100.0, EventId = 3, UserId = 3 }
    );
}
}
