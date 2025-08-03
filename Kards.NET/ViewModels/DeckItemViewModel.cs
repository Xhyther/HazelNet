using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class DeckItemViewModel
{
    public Decks Decks { get; }
    public DeckViewModel Parent { get; }

    public DeckItemViewModel(Decks decks, DeckViewModel parent)
    {
        Decks = decks;
        Parent = parent;
    }
    
    
    public string DeckName => Decks.DeckName;
    public string NumberOfCards => "Cards: " + Decks.NumberOfCards.ToString();
    public string LastAccess => "Last Studied: " + Decks.LastAcess.ToString();
}