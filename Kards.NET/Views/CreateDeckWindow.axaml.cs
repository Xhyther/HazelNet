using Avalonia.Controls;
using Avalonia.Interactivity;
using Kards.NET.Models;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class CreateDeckWindow : Window
{
    CreateDeckWindowViewModel _viewModel;
    public CreateDeckWindow(CreateDeckWindowViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _viewModel.CloseWindow = Close;
        DataContext = _viewModel;
    }
    
    public CreateDeckWindow(CreateDeckWindowViewModel viewModel, Decks deck)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _viewModel.DeckName = deck.DeckName;
        _viewModel.CloseWindow = Close;
        DataContext = _viewModel;
    }

   

    private void CancelDeckCreation(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
    
   
}