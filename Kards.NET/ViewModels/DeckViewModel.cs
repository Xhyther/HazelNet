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
   public ObservableCollection<Decks> Decks { get; set; } = new ObservableCollection<Decks>();

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
         Decks.Add(deck); // No manual OnPropertyChanged needed
   }
   

   [RelayCommand]
   public void CreateNewDeckCommand()
   {
      var window = new CreateDeckWindow(_createDeckWindowViewModel);
      window.Closed += async (s, e) => await LoadAllDecks();
      window.Show();
   }

   [RelayCommand]
   public void EditDeckCommand()
   {
      try
      {
         Console.WriteLine("Editing deck....");
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }
   
   
}