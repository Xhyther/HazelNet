using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kards.NET.Models;

public class Decks
{
    public int Id { get; set; }
    public string DeckName { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime LastAcess { get; set; }
    
    public ICollection<Cards> Cards { get; set; } = new List<Cards>();
    public int NumberOfCards { get; set; }
}