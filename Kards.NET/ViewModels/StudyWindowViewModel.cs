using System.Collections.ObjectModel;
using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class StudyWindowViewModel
{
    public Decks deck {get; set;}
    public ObservableCollection<Cards> Card { get; set; }
    public string currentDisplay { get; set; }

    public StudyWindowViewModel()
    {
        currentDisplay = "sample front";
    }

    public void LoadCard(Decks d)
    {
        deck = d;
    }
    
}