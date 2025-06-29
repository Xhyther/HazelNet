using System.Collections.Generic;
using System.Threading.Tasks;
using Kards.NET.DBContext;
using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Kards.NET.Services;

public class DeckService
{
    private readonly ApplicationDbContext _db;

    public DeckService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    //Get all Decks
    public async Task<List<Decks>> GetAllDecks() => await _db.Decks.ToListAsync();
    //Get a Deck by Id
    public async Task<Decks?> GetDeckByName(int id) => await _db.Decks.FindAsync(id);

    public async Task AddDeckAsync(Decks deck)
    {
        _db.Decks.Add(deck);
        await _db.SaveChangesAsync();
    }
    
    public async Task UpdateDeckAsync(Decks deck)
    {
        _db.Decks.Update(deck);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteDeckAsync(int id)
    {
        var decks = await _db.Decks.FindAsync(id);
        if (decks != null)
        {
            _db.Decks.Remove(decks);
            await _db.SaveChangesAsync();
        }
    }

}