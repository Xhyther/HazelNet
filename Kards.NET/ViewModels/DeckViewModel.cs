using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Models;
using Kards.NET.Services;
using Kards.NET.Views;


namespace Kards.NET.ViewModels;

public partial class DeckViewModel : ViewModelBase, INotifyPropertyChanged
{

   private readonly DeckService _deckService;
   private readonly CreateDeckWindowViewModel _createDeckWindowViewModel;
   public ObservableCollection<DeckItemViewModel> Decks { get; set; } = new ObservableCollection<DeckItemViewModel>();

   //Overload Constructor for testing
   

   public DeckViewModel(DeckService deckService, CreateDeckWindowViewModel  createDeckWindowViewModel)
   {
      //Dependency Injection
      _deckService = deckService;
      _createDeckWindowViewModel = createDeckWindowViewModel;
      LoadAllDecks();
   }

   public async Task LoadAllDecks()
   {
      Decks.Clear();
      foreach (var deck in await _deckService.GetAllDecksAsync())
         Decks.Add(new DeckItemViewModel(deck, this)); // No manual OnPropertyChanged needed
   }
   

   [RelayCommand]
   public void CreateNewDeckCommand()
   {
      var window = new CreateDeckWindow(_createDeckWindowViewModel);
      window.Closed += async (s, e) => await LoadAllDecks();
      window.Show();
   }

   [RelayCommand]
   public void EditDeck(Decks? deck)
   {
      if (deck == null) return;
        
      try
      {
         Console.WriteLine($"Editing deck: {deck.DeckName} (ID: {deck.Id})");
         var window = new CreateDeckWindow(_createDeckWindowViewModel,deck);
         window.Closed += async (s, e) => await LoadAllDecks();
         window.Show();
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }
    
   [RelayCommand]
   public void StudyDeck(Decks? deck)
   {
      if (deck == null) return;
        
      try
      {
         Console.WriteLine($"Studying deck: {deck.DeckName} (ID: {deck.Id})");
         // Add your study logic here
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }
   
   
   
   
}