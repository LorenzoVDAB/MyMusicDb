namespace MyMusicDbData.Repositories.Interfaces;

using MyMusicDbData.Models; 

public interface ITracksRepository {
    Task<List<Album>?> GetAlbumsFromIdsAsync(List<int>? Ids);
    Task<List<Track>?> GetTracksFromIdsAsync(List<int>? Ids); 
}
