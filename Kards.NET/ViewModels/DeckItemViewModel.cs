using CommunityToolkit.Mvvm.ComponentModel;
using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class DeckItemViewModel
{
    public Decks Deck { get; }
    public DeckViewModel Parent { get; }
    
    public string DeckName => Deck.DeckName;
    
    public string NumberOfCards => Deck.Cards.Count + " cards"; 

    public string LastAccess => "Last Studied: " + Deck.LastAcess;

    public DeckItemViewModel(Decks decks, DeckViewModel parent)
    {
        Deck = decks;
        Parent = parent;
        
    }
    
}