using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class DeckItemViewModel
{
    public Decks Deck { get; }
    public DeckViewModel Parent { get; }

    public DeckItemViewModel(Decks decks, DeckViewModel parent)
    {
        Deck = decks;
        Parent = parent;
    }
    
    
    public string DeckName => Deck.DeckName;
    public string NumberOfCards => "Cards: " + Deck.NumberOfCards.ToString();
    public string LastAccess => "Last Studied: " + Deck.LastAcess.ToString();
}