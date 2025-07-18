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
        var vm = App.Services.GetRequiredService<CreateDeckWindowViewModel>();
        vm.CloseWindow = Close;
        DataContext = vm;
    }

    private void CancelDeckCreation(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}