using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kards.NET.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   
   public INavigationService Navigation{ get; }
   
   private readonly DashboardViewModel _dashboardViewModel;
   private readonly DeckViewModel _deckViewModel;
   private readonly StatsViewModel _statsViewModel;
   private readonly StudyViewModel _studyViewModel;

   public MainWindowViewModel()
   {
      //For design Time.....
   }
   public MainWindowViewModel(
      INavigationService navigation,
      DashboardViewModel dashboardViewModel,
      DeckViewModel deckViewModel,
      StatsViewModel statsViewModel,
      StudyViewModel studyViewModel)
   {
      _dashboardViewModel = dashboardViewModel;
      _deckViewModel = deckViewModel;
      _statsViewModel = statsViewModel;
      _studyViewModel = studyViewModel;
      Navigation = navigation;
      Navigation.NavigateTo(_deckViewModel,"My Decks");// default view
   }
   

   [RelayCommand]
   public void DashboardView()
   {
      Navigation.NavigateTo(_dashboardViewModel, "Dashboard");
   }
   
   [RelayCommand]
   public void DeckView()
   {
      Navigation.NavigateTo(_deckViewModel, "My Deck");
   }
   
   [RelayCommand]
   public void StudyView()
   {
      Navigation.NavigateTo(_studyViewModel, "Study");
   }
   
   [RelayCommand]
   public void StatsView()
   {
      Navigation.NavigateTo(_statsViewModel, "Stats");
   }
}