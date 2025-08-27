using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Models;
using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public partial class EditDeckWindowViewModel : ViewModelBase
{
    //Public properties
    public required Decks Decks {get;set;}
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
            CloseWindow.Invoke();
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