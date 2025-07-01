using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Kards.NET.DBContext;
using Kards.NET.Services;
using Kards.NET.ViewModels;
using Kards.NET.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=Kards.db"));
        
        serviceCollection.AddScoped<DeckService>();
        //Add here card Service
        serviceCollection.AddScoped<CardService>();
        
      
        serviceCollection.AddTransient<DashboardViewModel>();
        serviceCollection.AddTransient<DeckViewModel>();
        serviceCollection.AddTransient<StatsViewModel>();
        serviceCollection.AddTransient<StudyViewModel>();
        serviceCollection.AddTransient<MainWindowViewModel>(); // final shell
        
        Services =  serviceCollection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            var mainVM = Services.GetRequiredService<MainWindowViewModel>();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainVM
            };;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}