using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Kards.NET.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   [ObservableProperty]
   private ViewModelBase _currentPage = new DashboardViewModel();

   [RelayCommand]
   public void DashboardView()
   {
        CurrentPage = new DashboardViewModel();
   }
   
   [RelayCommand]
   public void DeckView()
   {
      CurrentPage = new DeckViewModel();
   }
   
   [RelayCommand]
   public void StudyView()
   {
      CurrentPage = new StudyViewModel();
   }
   
   [RelayCommand]
   public void StatsView()
   {
      CurrentPage = new StatsViewModel();
   }
}