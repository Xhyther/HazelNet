using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public class CreateDeckViewModel
{
    private readonly DeckService _deckService;

    public CreateDeckViewModel(DeckService deckService)
    {
        _deckService = deckService;
    }
}