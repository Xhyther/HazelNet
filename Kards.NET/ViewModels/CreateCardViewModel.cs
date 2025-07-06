using Kards.NET.Services;

namespace Kards.NET.ViewModels;

public class CreateCardViewModel
{
    private readonly CardService _cardService;
    
    public CreateCardViewModel(CardService cardService)
    {
        //Dependency Injection
        _cardService = cardService;
    }
}