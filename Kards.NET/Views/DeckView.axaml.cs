using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Kards.NET.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Views;

public partial class DeckView : UserControl
{
    public DeckView()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<DeckViewModel>();
    }
}