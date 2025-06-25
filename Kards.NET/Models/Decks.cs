namespace Kards.NET.Models;

public class Decks
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Cards? Cards { get; set; }
}