using System.Collections.ObjectModel;
using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class StudyWindowViewModel
{
    private Decks Deck {get; set;} =  new();
    public ObservableCollection<Cards> Kards { get; set; } = new();

    
    
    public void LoadCard(Decks d)
    {
       
        Deck = d;
        Kards.Clear();

        foreach (var c in Deck.Cards)
        {
            Kards.Add(c);
        }
    }
    
}