using Kards.NET.Models;

namespace Kards.NET.ViewModels;


public class EditDeckItemViewModel
{
    public EditDeckItemViewModel(EditDeckWindowViewModel editDeckWindowViewModel, Cards cards)
    {
        Parent = editDeckWindowViewModel;
        Card = cards;
    }
    public  EditDeckWindowViewModel Parent { get; set; }
    public Cards Card { get; set; }
    
    
}