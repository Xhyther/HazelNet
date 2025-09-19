using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kards.NET.DBContext;

public class DecksEntityTypeConfiguration :  IEntityTypeConfiguration<Decks>
{
    public void Configure(EntityTypeBuilder<Decks> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.DeckName).HasMaxLength(100).IsRequired();
        
        builder.HasMany(d => d.Cards)
            .WithOne(c => c.Decks)
            .HasForeignKey(d => d.DeckId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}