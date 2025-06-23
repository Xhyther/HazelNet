using Avalonia.Controls;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}