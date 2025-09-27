using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Kards.NET.Models;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class StudyWindow : Window
{
    public StudyWindow()
    {
        InitializeComponent();
        DataContext = new StudyWindowViewModel();
    }
    
    public StudyWindow(StudyWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
    
    public StudyWindow(StudyWindowViewModel vm, Decks d)
    {
        InitializeComponent();
        DataContext = vm;
        vm.LoadCard(d);
    }
}