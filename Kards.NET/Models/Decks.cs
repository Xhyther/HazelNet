using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kards.NET.Models;

public class Decks
{
    public int Id { get; set; }
    
    [StringLength(30, ErrorMessage = "Deck Name cannot be longer than 30 characters.")]
    [Required]
    public string DeckName { get; set; }
    
    public string? DeckDescription { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime LastAcess { get; set; }
    
    public ICollection<Cards> Cards { get; set; } = new List<Cards>();
}