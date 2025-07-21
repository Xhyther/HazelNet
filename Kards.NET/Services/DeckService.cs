using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Kards.NET.DBContext;
using Kards.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kards.NET.Services;

public class DeckService
{
    private readonly ApplicationDbContext _db;
    public DeckService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    //Get all Decks
    public async Task<List<Decks>> GetAllDecksAsync()
    {
 
        return await _db.Decks.AsNoTracking().ToListAsync();
      
    } 
    //Get a Deck by Id
    public async Task<Decks?> GetDeckByName(int id) => await _db.Decks.FindAsync(id);

    public async Task AddDeckAsync(Decks deck)
    {
        try
        {
            _db.Decks.Add(deck);
            var changes = await _db.SaveChangesAsync();
            Console.WriteLine($"Saved successfully. {changes} records affected.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Save error: {ex.ToString()}");
            throw;
        }
       
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
    
    //Implement Card functions
    public async Task AddCardToDeckAsync(int deckId, Cards card)
    {
        var decks = await _db.Decks.FindAsync(deckId);
        if (decks == null)
            throw new Exception($"Deck with ID {deckId} not found");
        else
        {
            card.DeckId = deckId;
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();
        }
    }
    
    public async Task<List<Cards>> GetAllCardsByDeckAsync(int deckId)
    {
        return await _db.Cards.Where(x => x.DeckId == deckId).ToListAsync();
    }

    

}