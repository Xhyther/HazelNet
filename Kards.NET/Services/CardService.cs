using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kards.NET.DBContext;
using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Kards.NET.Services;

public class CardService
{
    private readonly ApplicationDbContext _db;

    public CardService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    //List All cards
    public async Task<List<Cards>> GetAllCardsAsync() => await _db.Cards.ToListAsync();

    //List all Cards by DeckId
    public async Task<List<Cards>> GetAllCardsByDeckAsync(int deckId)
    {
        return await _db.Cards.Where(x => x.DeckId == deckId).ToListAsync();
    }

    
    public async Task UpdateCardAsync(Cards card)
    {
        _db.Cards.Update(card);
        await _db.SaveChangesAsync();
    }
    
    //Delete Cards by specific ID
    public async Task DeleteCardAsync(int id)
    {
       var cards =  await _db.Cards.FindAsync(id);
       if (cards != null)
       {
           _db.Cards.Remove(cards);
           await _db.SaveChangesAsync();
       }
    }
    
    
}