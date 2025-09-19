using Avalonia.Controls;
using Kards.NET.ViewModels;


namespace Kards.NET.Views;

public partial class MainWindow : Window
{
    MainWindowViewModel _viewModel;

    //For Design preview
    public MainWindow()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
            DataContext = new MainWindowViewModel();
    }
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }

 
}