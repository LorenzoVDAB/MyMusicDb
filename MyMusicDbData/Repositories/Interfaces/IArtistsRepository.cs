using MyMusicDbData.Models;

namespace MyMusicDbData.Repositories.Interfaces;

public interface IArtistsRepository {
    Task<List<Artist>> GetAllAsync(int page, int pageSize);
    Task<Artist?> GetByIdAsync(int id);
    Task<Artist> AddAsync(Artist artist);
    Task<Artist> UpdateAsync(Artist artist);
    Task DeleteAsync(int id);
}
