namespace Kards.NET.Models;

public class Cards
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}