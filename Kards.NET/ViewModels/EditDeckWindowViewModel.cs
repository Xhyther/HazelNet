using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Models;
using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public partial class EditDeckWindowViewModel : ViewModelBase
{
    //Public properties
    public required Decks Decks {get;set;}
    public ObservableCollection<EditDeckItemViewModel> CardS { get; set; } = new();
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
        CardS.Clear();

        if (deck.Cards.Count > 0)
        {
            foreach (var card in deck.Cards)
                CardS.Add(new EditDeckItemViewModel(this, card));
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
    public async Task UpdateCardButton()
    {
        try
        {
            Console.WriteLine($"Attempting to edit Card: {CardS.FirstOrDefault()?.Card}");
            Decks.LastAcess = DateTime.Now;
            await _deckService.UpdateDeckAsync(Decks);
           
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
            
            CardS.Add(new EditDeckItemViewModel(this, card));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
       
        FrontName = string.Empty;
        BackDescription = string.Empty;

    }

    [RelayCommand]
    public async Task ClearAllCardsButton()
    {
        try
        {
            CardS.Clear();
            await _deckService.DeleteAllCardsInDeckAsync(DeckId);
            Console.WriteLine("Cards successfully Cleared!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            Console.WriteLine(e.Message);
            throw;
        }
    }

    [RelayCommand]
    public async Task DeleteCardByIdButton(int cardId)
    {

        try
        {
            Console.WriteLine($"Attempting to delete card: {cardId}");
            await _deckService.DeleteCardByIdAsync(DeckId, cardId);
            Console.WriteLine("Successfully deleted card!");

            var cardToRemove = CardS.FirstOrDefault(c => c.Card.Id == cardId);
            if (cardToRemove != null)
                CardS.Remove(cardToRemove);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    
}