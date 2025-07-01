using Avalonia.Controls;
using Kards.NET.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<MainWindowViewModel>();
    }
}