using Avalonia.Controls;
using Avalonia.Interactivity;
using Kards.NET.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Views;

public partial class CreateDeckWindow : Window
{
    public CreateDeckWindow()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<CreateDeckWindowViewModel>();
    }

    private void CancelDeckCreation(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}