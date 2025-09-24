using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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
    public async Task<List<Decks>> GetAllDecksAsync()
    {
 
        return await _db.Decks
            .Include(d => d.Cards) // This is the crucial part
            .ToListAsync();
      
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
            Console.WriteLine($"Save error: {ex}");
            throw;
        }
       
    }
    
    public async Task UpdateDeckAsync(Decks deck)
    {
        
        var existingDeck = await _db.Decks.FindAsync(deck.Id);

        if (existingDeck is not null)
        {
            // Update only the fields that changed
            existingDeck.DeckName = deck.DeckName;
            existingDeck.LastAcess = deck.LastAcess;

            await _db.SaveChangesAsync();
        }
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

    public async Task DeleteAllCardsInDeckAsync(int id)
    {
        var deck = await _db.Decks
            .Include(d => d.Cards)
            .FirstOrDefaultAsync(d => d.Id == id);
        
        deck?.Cards.Clear();
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCardByIdAsync(int deckId, int cardId)
    {
        var deck = await _db.Decks
            .Include(d => d.Cards)
            .FirstOrDefaultAsync(d => d.Id == deckId);

        var card = deck?.Cards.FirstOrDefault(c => c.Id == cardId);
        if (card != null)
        {
            deck?.Cards.Remove(card);
            await _db.SaveChangesAsync();
        }

    }
    
    //Implement Card functions
    public async Task AddCardToDeckAsync(Decks deck, Cards card)
    {
        var existingDeck = await _db.Decks
            .Include(d => d.Cards) // make sure cards are loaded
            .FirstOrDefaultAsync(d => d.Id == deck.Id);

        if (existingDeck == null)
            throw new InvalidOperationException($"Deck with ID {deck.Id} not found.");

        // Set the foreign key relationship
        card.DeckId = existingDeck.Id; // Assuming your Cards model has a DeckId property
    
        existingDeck.Cards.Add(card);
    
        // Optional: Update the LastAccess time since we're modifying the deck
        existingDeck.LastAcess = DateTime.Now;

        await _db.SaveChangesAsync();
    }



    
    public async Task<List<Cards>> GetAllCardsByDeckAsync(int deckId)
    {
        return await _db.Cards.Where(x => x.DeckId == deckId).ToListAsync();
    }

    

}