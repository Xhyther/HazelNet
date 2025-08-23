using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Models;
using Kards.NET.Services;
using Kards.NET.Views;
using Microsoft.Extensions.DependencyInjection;


namespace Kards.NET.ViewModels;

public partial class DeckViewModel : ViewModelBase, INotifyPropertyChanged
{
   public INavigationService Navigation { get; }
   private readonly DeckService _deckService;
   private readonly CreateDeckWindowViewModel _createDeckWindowViewModel;
   private readonly EditDeckWindowViewModel _editDeckWindowViewModel;
   
   public ObservableCollection<DeckItemViewModel> Decks { get; set; } = new ObservableCollection<DeckItemViewModel>();

   //Overload Constructor for testing
   

   public DeckViewModel(
      INavigationService navigation,
      DeckService deckService, 
      CreateDeckWindowViewModel  createDeckWindowViewModel,
      EditDeckWindowViewModel editDeckWindowViewModel
      )
   {
      //Dependency Injection
      Navigation = navigation;
      _deckService = deckService;
      _createDeckWindowViewModel = createDeckWindowViewModel;
      _editDeckWindowViewModel = editDeckWindowViewModel;
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
         Navigation.NavigateTo(_editDeckWindowViewModel, deck.DeckName.ToString());
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