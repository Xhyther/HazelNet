using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public class CreateDeckWindowViewModel
{
    private readonly DeckService _deckService;

    public CreateDeckWindowViewModel(DeckService deckService)
    {
        _deckService = deckService;
    }
}