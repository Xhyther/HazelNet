using System;
using System.Collections.ObjectModel;
using Kards.NET.Models;
using System.Linq;


namespace Kards.NET.ViewModels;

public class DeckViewModel : ViewModelBase
{
   public ObservableCollection<Decks> Decks { get; set; }
   public ObservableCollection<Cards> Cards { get; set; }

   public DeckViewModel()
   {
       Cards = new ObservableCollection<Cards>
       {
           new Cards
           {
               Id = 1,
               CardName = "Card 1",
               CardDescription = "Card 1 description",
               CreationDate = DateTime.Now,
               DeckId = 1
           },
           new Cards
           {
               Id = 2,
               CardName = "Card 2",
               CardDescription = "Card 2 description",
               CreationDate = DateTime.Now,
               DeckId = 2
           }
       };
       Decks = new ObservableCollection<Decks>
       {
           new Decks
           {
               Id = 1,
               DeckName = "Laptops",
               DeckDescription = "Collection of Laptops and Specs",
               CreationDate = DateTime.Now,
               LastAcess = DateTime.Now,
               NumberOfCards = Cards.Count(c => c.DeckId == 1)
           },
           new Decks
           {
               Id = 2,
               DeckName = "Pokedex",
               DeckDescription = "Collection of Pokemon Cards",
               CreationDate = DateTime.Now,
               LastAcess = DateTime.Now,
               NumberOfCards = Cards.Count(c => c.DeckId == 2)
           }
       };
   }
}