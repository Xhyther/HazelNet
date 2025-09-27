using System;
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
   private readonly CreateDeckWindowViewModel _createDeckWindowViewModel;
   private readonly EditDeckWindowViewModel _editDeckWindowViewModel;
   private readonly StudyWindowViewModel _studyWindowViewModel;
   
   public ObservableCollection<DeckItemViewModel> Decks { get; set; } = new ObservableCollection<DeckItemViewModel>();

   //Overload Constructor for testing
   

   public DeckViewModel(
      DeckService deckService, 
      CreateDeckWindowViewModel  createDeckWindowViewModel,
      EditDeckWindowViewModel editDeckWindowViewModel,
      StudyWindowViewModel studyWindowViewModel
      )
   {
      //Dependency Injection
      _deckService = deckService;
      _createDeckWindowViewModel = createDeckWindowViewModel;
      _editDeckWindowViewModel = editDeckWindowViewModel;
      _studyWindowViewModel = studyWindowViewModel;
      _ = Task.Run(LoadAllDecks);
   }

   private async Task LoadAllDecks()
   {
      var currentDecks = await _deckService.GetAllDecksAsync();
    
      // Clear and rebuild the collection to ensure fresh data
      Decks.Clear();
      foreach (var deck in currentDecks)
      {
         Decks.Add(new DeckItemViewModel(deck, this));
      }
   }
   
   
   

   [RelayCommand]
   public void CreateNewDeckCommand()
   {
      var window = new CreateDeckWindow(_createDeckWindowViewModel);
      window.Closed += async (s, e) => await LoadAllDecks();
      window.Show();
   }

   [RelayCommand]
   private void EditDeck(Decks? deck)
   {
      if (deck == null) return;
      try
      {
         Console.WriteLine($"Editing deck: {deck.DeckName} (ID: {deck.Id})");
         var window = new EditDeckWindow(_editDeckWindowViewModel, deck);
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
         var window = new StudyWindow(_studyWindowViewModel, deck);
         window.Closed += async (s, e) => await LoadAllDecks();
         window.Show();
         // Add your study logic here
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }
   
   

   
   
   
}