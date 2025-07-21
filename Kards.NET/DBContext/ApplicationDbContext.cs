using System;
using System.IO;
using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Kards.NET.DBContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<Decks> Decks { get; set; }
    public DbSet<Cards> Cards { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}
 
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CardsEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DecksEntityTypeConfiguration());
    }
}