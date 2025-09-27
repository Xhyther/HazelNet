using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Kards.NET.Models;
using Kards.NET.ViewModels;

namespace Kards.NET.Views;

public partial class StudyWindow : Window
{
    
    public StudyWindow(StudyWindowViewModel vm, Decks d)
    {
        InitializeComponent();
        DataContext = vm;
        vm.LoadCard(d);
    }
    
    public void Next(object source, RoutedEventArgs args)
    {
        Slides.Next();
    }

    public void Previous(object source, RoutedEventArgs args) 
    {
        Slides.Previous();
    }
}