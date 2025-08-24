using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class EditDeckWindowViewModel : ViewModelBase
{
    public Decks Decks {get;set;}
    public string DeckName  => Decks.DeckName;
    
   
    
    
    
}