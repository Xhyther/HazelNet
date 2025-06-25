using System;

namespace Kards.NET.Models;

public class Decks
{
    public int Id { get; set; }
    public required string DeckName { get; set; }
    public string? DeckDescription { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime LastAcess { get; set; }
    
}