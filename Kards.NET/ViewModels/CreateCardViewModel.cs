using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public class CreateCardViewModel
{
    private readonly DeckService _deckService;
    
    public CreateCardViewModel(DeckService deckService)
    {
        //Dependency Injection
        _deckService = deckService;
    }
}