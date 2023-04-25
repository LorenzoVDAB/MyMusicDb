using MyMusicDbData.Models;
using MyMusicDbData.Repositories.SQL; 

namespace MyMusicDbServices; 

public class ArtistsService {
    private readonly SQLArtistsRepository repository; 

    public ArtistsService(SQLArtistsRepository repository) {
        this.repository = repository;
    }

    public async Task<IEnumerable<Artist>> GetAllAsync(int page, int pageSize) => await repository.GetAllAsync(page, pageSize);
    public async Task<Artist?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);
    public async Task<Artist> AddAsync(Artist artist) => await repository.AddAsync(artist);
    public async Task<Artist> UpdateAsync(Artist artist) => await repository.UpdateAsync(artist);
    public async Task DeleteAsync(int id) => await repository.DeleteAsync(id);
    public async Task SaveAsync() => await repository.SaveAsync();
}