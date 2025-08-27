using System;
using System.Collections.Generic;


namespace Kards.NET.Models;

public class Decks
{
    public int Id { get; set; }
    public string DeckName { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime LastAcess { get; set; } = DateTime.Now;
    
    public ICollection<Cards> Cards { get; set; } = new List<Cards>();
    
}