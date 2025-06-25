using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kards.NET.DBContext;

public class CardsEntityTypeConfiguration :IEntityTypeConfiguration<Cards>
{
    public void Configure(EntityTypeBuilder<Cards> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.CardName).HasMaxLength(100).IsRequired();
        
        builder.HasOne(c => c.Decks)
            .WithMany(d => d.Cards)
            .HasForeignKey(d => d.DeckId);
    }
}