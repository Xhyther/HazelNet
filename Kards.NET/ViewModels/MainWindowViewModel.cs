using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   [ObservableProperty]
   private ViewModelBase _currentPage;
   
   private readonly DashboardViewModel _dashboardViewModel;
   private readonly DeckViewModel _deckViewModel;
   private readonly StatsViewModel _statsViewModel;
   private readonly StudyViewModel _studyViewModel;

   public MainWindowViewModel(
      DashboardViewModel dashboardViewModel,
      DeckViewModel deckViewModel,
      StatsViewModel statsViewModel,
      StudyViewModel studyViewModel)
   {
      _dashboardViewModel = dashboardViewModel;
      _deckViewModel = deckViewModel;
      _statsViewModel = statsViewModel;
      _studyViewModel = studyViewModel;

      _currentPage = _dashboardViewModel; // default view
   }
   
   private string _pageTitle = "Dashboard";

   public string PageTitle
   {
      get => _pageTitle;
      set => SetProperty(ref _pageTitle, value);
   }

   [RelayCommand]
   public void DashboardView()
   {
      CurrentPage = _dashboardViewModel;
        PageTitle = "Dashboard";
        
   }
   
   [RelayCommand]
   public void DeckView()
   {
      CurrentPage = _deckViewModel;
      PageTitle = "My Decks";
      
   }
   
   [RelayCommand]
   public void StudyView()
   {
      CurrentPage = _studyViewModel;
      PageTitle = "Study";
   }
   
   [RelayCommand]
   public void StatsView()
   {
      CurrentPage = _statsViewModel;
      PageTitle = "Statistics";
   }
}