using System;
using System.IO;
using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        optionsBuilder.UseSqlite("Data Source=Kards.db");
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}