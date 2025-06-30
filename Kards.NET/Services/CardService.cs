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
    public async Task<List<Cards>> GetAllCardsByDeckAsync(int DeckID)
    {
        return await _db.Cards.Where(x => x.DeckId == DeckID).ToListAsync();
    }
}