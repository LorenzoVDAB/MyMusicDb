using Microsoft.EntityFrameworkCore;
using MyMusicDbData.Models;
using MyMusicDbData.Repositories.Interfaces;
using System.Numerics;

namespace MyMusicDbData.Repositories.SQL;

public class SQLArtistsRepository : IArtistsRepository {
    private readonly MyMusicDbContext context; 

    public SQLArtistsRepository(MyMusicDbContext context) {
        this.context = context; 
    }

    public async Task<Artist> AddAsync(Artist artist) {
        context.Artists.Add(artist);
        await context.SaveChangesAsync();
        return artist; 
    }

    public async Task DeleteAsync(int id) {
        Artist? artist = await context.Artists.FindAsync(id);
        if (artist != null) {
            context.Artists.Remove(artist);
            await context.SaveChangesAsync();
        }
    }

    //Using pagination in case the database gets big 
    public async Task<List<Artist>> GetAllAsync(int page, int pageSize) {
        return await context.Artists
            .OrderBy(a => a.Id)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync(); 
    }

    public async Task<Artist?> GetByIdAsync(int id) {
        return await context.Artists.FindAsync(id); 
    }

    public async Task<Artist> UpdateAsync(Artist artist) {
        try {
            context.Artists.Update(artist);
            await context.SaveChangesAsync();
            return artist;
        } catch (DbUpdateException ex) {
            throw new Exception("Something went wrong while trying to update the database. ", ex);
        }
    }
}
