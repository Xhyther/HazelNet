using Avalonia.Controls;
using Avalonia.Interactivity;
using Kards.NET.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Views;

public partial class CreateDeckWindow : Window
{
    CreateDeckWindowViewModel _viewModel;
    public CreateDeckWindow(CreateDeckWindowViewModel ViewModel)
    {
        InitializeComponent();
        _viewModel = ViewModel;
        _viewModel.CloseWindow = Close;
        DataContext = _viewModel;
    }

   

    private void CancelDeckCreation(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
    
   
}