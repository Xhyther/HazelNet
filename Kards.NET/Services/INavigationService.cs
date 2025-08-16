using System.ComponentModel;
using Kards.NET.ViewModels;

namespace Kards.NET.Services;

public interface INavigationService
{
    ViewModelBase CurrentPage { get; }
    string PageTitle { get; }
    void NavigateTo(ViewModelBase vm, string title);
}