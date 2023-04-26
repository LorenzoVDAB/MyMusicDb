using Microsoft.EntityFrameworkCore;
using MyMusicDbData.Models;
using MyMusicDbData.Repositories.Interfaces;

namespace MyMusicDbData.Repositories.SQL;

public class SQLTracksRepository : ITracksRepository {
    private readonly MyMusicDbContext context; 

    public SQLTracksRepository(MyMusicDbContext context) {
        this.context = context; 
    }

    public async Task<List<Album>?> GetAlbumsFromIdsAsync(List<int>? Ids) {
        if (Ids == null) {
            return null;
        }

        List<Album> albums = await context.Albums.Where(a => Ids.Contains(a.Id)).ToListAsync();
        return albums;
    }

    public async Task<List<Track>?> GetTracksFromIdsAsync(List<int>? Ids) {
        if (Ids == null) { 
            return null; 
        }

        List<Track> singles = await context.Tracks.Where(s => Ids.Contains(s.Id)).ToListAsync();
        return singles; 
    }
}
