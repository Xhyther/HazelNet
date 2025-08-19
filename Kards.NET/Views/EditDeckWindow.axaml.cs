using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class EditDeckWindow : Window
{
    EditDeckWIndowViewModel _viewModel;

    public EditDeckWindow()
    {
        InitializeComponent();
        if(Design.IsDesignMode)
            DataContext = new EditDeckWIndowViewModel();
    }
    public EditDeckWindow(EditDeckWIndowViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }
}