using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Kards.NET.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   [ObservableProperty]
   private ViewModelBase _currentPage = new DashboardViewModel();
   
   private string _pageTitle = "Dashboard";

   public string PageTitle
   {
      get => _pageTitle;
      set => SetProperty(ref _pageTitle, value);
   }

   [RelayCommand]
   public void DashboardView()
   {
        CurrentPage = new DashboardViewModel();
        PageTitle = "Dashboard";
        
   }
   
   [RelayCommand]
   public void DeckView()
   {
      CurrentPage = new DeckViewModel();
      PageTitle = "My Decks";
      
   }
   
   [RelayCommand]
   public void StudyView()
   {
      CurrentPage = new StudyViewModel();
      PageTitle = "Study";
   }
   
   [RelayCommand]
   public void StatsView()
   {
      CurrentPage = new StatsViewModel();
      PageTitle = "Statistics";
   }
}