using System;
using System.Collections.ObjectModel;
using Kards.NET.Models;
using System.Linq;
using Kards.NET.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Kards.NET.ViewModels;

public class DeckViewModel : ViewModelBase
{
   private readonly DeckService _deckService;

   public ObservableCollection<Decks> Decks { get; set; } = new();

   public DeckViewModel()
   {
      _deckService = App.Services.GetRequiredService<DeckService>();
   }
}