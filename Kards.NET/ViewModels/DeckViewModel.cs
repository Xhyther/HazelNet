using System.Collections.ObjectModel;
using Kards.NET.Models;
using Kards.NET.Services;


namespace Kards.NET.ViewModels;

public class DeckViewModel : ViewModelBase
{
   private readonly DeckService _deckService;

   public ObservableCollection<Decks> Decks { get; set; } = new();

   //Overload Constructor for testing
   
   
   public DeckViewModel(DeckService deckService)
   {
      //Dependency Injection
      _deckService = deckService;
   }

   public async void LoadAAllDecks()
   {
      var decks = await _deckService.GetAllDecks();
      foreach (var deck in decks)
         Decks.Add(deck);
   }
}