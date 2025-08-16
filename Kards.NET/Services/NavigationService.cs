using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Kards.NET.ViewModels;

namespace Kards.NET.Services;

public partial class NavigationService: ObservableObject,  INavigationService
{
    [ObservableProperty]
    private ViewModelBase _currentPage;
    
    [ObservableProperty]
    private string _pageTitle;
    
    
    public void NavigateTo(ViewModelBase vm, string title)
    {
        CurrentPage = vm;
        PageTitle = title;
    }
}