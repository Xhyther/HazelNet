using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Kards.NET.Models;
using Kards.NET.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Views;

public partial class EditDeckWindow : Window
{
    public EditDeckWindow()
    {
        InitializeComponent();
    }

    public EditDeckWindow(EditDeckWindowViewModel viewModel, Decks deck)
    {
        if (deck == null) return;
        
        InitializeComponent();
        viewModel.LoadDeck(deck);
        viewModel.CloseWindow = Close;
        DataContext = viewModel;
    }
    
    private void Back_to_Deck_Click(object? sender, RoutedEventArgs e)
    {
        // Logic to execute when the button is clicked
        this.Close();
    }
}