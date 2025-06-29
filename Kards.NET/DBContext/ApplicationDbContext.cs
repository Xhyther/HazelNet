using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Kards.NET.DBContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<Decks> Decks { get; set; }
    public DbSet<Cards> Cards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Kards.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CardsEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DecksEntityTypeConfiguration());
    }
}