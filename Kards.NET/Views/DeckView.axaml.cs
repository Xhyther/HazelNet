using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Kards.NET.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Views;

public partial class DeckView : UserControl
{
    DeckViewModel _viewModel;
    
    public DeckView()
    {
        InitializeComponent();
        
    }
    
    public DeckView(DeckViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }
    
}