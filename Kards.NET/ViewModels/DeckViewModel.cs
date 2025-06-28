using System;
using System.Collections.ObjectModel;
using Kards.NET.Models;

namespace Kards.NET.ViewModels;

public class DeckViewModel : ViewModelBase
{
   public ObservableCollection<Decks> Decks { get; set; }

   public DeckViewModel()
   {
       Decks = new ObservableCollection<Decks>
       {
           new Decks
           {
               Id = 1,
               DeckName = "Laptops",
               DeckDescription = "Collection of Laptops and Specs",
               CreationDate = DateTime.Now,
               LastAcess = DateTime.Now,
           },
           new Decks
           {
               Id = 2,
               DeckName = "Pokedex",
               DeckDescription = "Collection of Pokemon Cards",
               CreationDate = DateTime.Now,
               LastAcess = DateTime.Now,
           }
       };
   }
}