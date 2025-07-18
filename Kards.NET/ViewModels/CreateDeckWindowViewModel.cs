using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Kards.NET.Models;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public partial class CreateDeckWindowViewModel : ObservableObject
{
    public Action CloseWindow { get; set; }
    
    private readonly DeckService _deckService;
    
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
                LastAcess = DateTime.Now
            };
            Console.WriteLine("New Deck Created!");
            await _deckService.AddDeckAsync(newDeck);
            CloseWindow?.Invoke();
            Console.WriteLine("Closing......");
        }
    }
}