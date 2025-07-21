using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Models;
using Kards.NET.Services;
using Kards.NET.Views;


namespace Kards.NET.ViewModels;

public partial class DeckViewModel : ViewModelBase
{

   private readonly DeckService _deckService;
   
   public ObservableCollection<Decks> Decks { get; set; } = new();
   

   //Overload Constructor for testing
   

   public DeckViewModel(DeckService deckService)
   {
      //Dependency Injection
      _deckService = deckService;
      LoadAllDecks();
   }

   public async Task LoadAllDecks()
   {
      var decks = new ObservableCollection<Decks>(await _deckService.GetAllDecksAsync());
      Decks.Clear();
      foreach (var deck in decks)
         Decks.Add(deck); // No manual OnPropertyChanged needed
   }
   

   [RelayCommand]
   public void CreateNewDeckCommand()
   {
      var window = new CreateDeckWindow();
      window.Show();
   }
   
}