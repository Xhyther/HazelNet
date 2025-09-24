using Kards.NET.Models;

namespace Kards.NET.ViewModels;


public class EditDeckItemViewModel
{
    public  EditDeckWindowViewModel Parent { get; set; }
    public Cards Card { get; set; }
    
    public EditDeckItemViewModel(EditDeckWindowViewModel editDeckWindowViewModel, Cards cards)
    {
        Parent = editDeckWindowViewModel;
        Card = cards;
    }
}