using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public class CreateCardWindowViewModel
{
    private readonly CardService _cardService;
    
    public CreateCardWindowViewModel(CardService cardService)
    {
        //Dependency Injection
        _cardService = cardService;
    }
}