using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Kards.NET.Models;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.ViewModels;

public partial class CreateDeckWindowViewModel : ObservableObject
{
    public Action CloseWindow { get; set; }

    private DeckService _deckService;
    
    
    
    [ObservableProperty]
    private string _deckName =  string.Empty;
    
    public CreateDeckWindowViewModel(DeckService deckService)
    {
        _deckService = deckService;
    }

    [RelayCommand]
    public async Task EnterDeckCreation()
    {
        if (!string.IsNullOrWhiteSpace(DeckName))
        {
            var newDeck = new Decks
            {
                DeckName = DeckName,
                LastAcess = DateTime.Now,
                CreationDate = DateTime.Now,
            };
            
            try
            {
                Console.WriteLine($"Attempting to save deck: {newDeck.DeckName}, {newDeck.CreationDate}");
                await _deckService.AddDeckAsync(newDeck);
                Console.WriteLine("Deck successfully saved!");
                CloseWindow.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving deck: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner exception: " + ex.InnerException.Message);
            }

        }
    }
    
}