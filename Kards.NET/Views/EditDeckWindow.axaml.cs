using Avalonia;
using Avalonia.Controls;
using Kards.NET.Models;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class EditDeckWindow : Window
{
    public EditDeckWindow()
    {
        InitializeComponent();
    }

    public EditDeckWindow(EditDeckWindowViewModel viewModel, Decks deck)
    {
        InitializeComponent();
        viewModel.Decks = deck;
        DataContext = viewModel;
    }
}