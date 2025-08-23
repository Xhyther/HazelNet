using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class EditDeckWindowView : Window
{
    EditDeckWindowViewModel _viewModel;

    public EditDeckWindowView()
    {
        InitializeComponent();
        if(Design.IsDesignMode)
            DataContext = new EditDeckWindowViewModel();
    }
    public EditDeckWindowView(EditDeckWindowViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }
}