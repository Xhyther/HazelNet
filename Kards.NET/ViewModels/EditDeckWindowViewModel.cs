using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Models;
using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public partial class EditDeckWindowViewModel : ViewModelBase
{
    //Public properties
    public required Decks Decks {get;set;}
    public ObservableCollection<Cards> Cards { get; set; } = new();
    public required Action CloseWindow { get; set; }
    
    public string FrontName { get; set; }
    public string BackDescription { get; set; }
    
    //Private Properties
    private int DeckId => Decks.Id;
    private readonly DeckService _deckService;
    
    

    public EditDeckWindowViewModel(DeckService deckService)
    {
        _deckService = deckService;
    }



    public void LoadDeck(Decks deck)
    {
        Decks = deck;
        Cards.Clear();

        if (deck.Cards != null)
        {
            foreach (var card in deck.Cards)
                Cards.Add(card);
        }
    }




    [RelayCommand]
    public async Task DeleteDeckButton()
    {
        try
        {
            Console.WriteLine($"Attempting to delete deck: {Decks.DeckName}");
            await _deckService.DeleteDeckAsync(DeckId);
            Console.WriteLine("Deck successfully deleted!");
            CloseWindow.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting deck: " + ex.Message);
            if (ex.InnerException != null)
                Console.WriteLine("Inner exception: " + ex.InnerException.Message);
        }
    }

    [RelayCommand]
    public async Task RenameDeckButton()
    {
        try
        {
            Console.WriteLine($"Attempting rename deck: {Decks.DeckName}");
            
            
            
            Decks.LastAcess = DateTime.Now;
            await _deckService.UpdateDeckAsync(Decks);
            CloseWindow.Invoke();
            
            
            
            Console.WriteLine("Deck successfully renamed!");
         
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating deck: " + ex.Message);
            if (ex.InnerException != null)
                Console.WriteLine("Inner exception: " + ex.InnerException.Message);
        }
    }

    [RelayCommand]
    public async Task AddCardButton()
    {
        Cards card = new Cards()
        {
            CardName = FrontName,
            CardDescription = BackDescription,
            CreationDate = DateTime.Now,
            DeckId = DeckId
        };
        Decks.LastAcess = DateTime.Now;
        try
        {
            Console.WriteLine("Card successfully added!");
            await _deckService.AddCardToDeckAsync(Decks, card);
            
            Cards.Add(card);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
       
        FrontName = string.Empty;
        BackDescription = string.Empty;

    }
    
    
    
    
}