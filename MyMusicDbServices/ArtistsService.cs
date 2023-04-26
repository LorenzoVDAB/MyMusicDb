using MyMusicDbData.Models;
using MyMusicDbData.Repositories.Interfaces;
using MyMusicDbServices.DTOs; 

namespace MyMusicDbServices; 

public class ArtistsService {
    private readonly IArtistsRepository repository;
    private readonly ITracksRepository tracksRepository; 

    public ArtistsService(IArtistsRepository repository, ITracksRepository tracksRepository) {
        this.repository = repository;
        this.tracksRepository = tracksRepository; 
    }

    public async Task<List<ArtistDTO>?> GetAllAsync(int page, int pageSize) {
        List<Artist>? artists = await repository.GetAllAsync(page, pageSize);
        
        if (artists == null) {
            return null; 
        }

        //Use LINQ for mapping the artist object to an ArtistDTO 
        List<ArtistDTO> artistDTOs = artists.Select(artist => new ArtistDTO() {
            Id = artist.Id,
            Name = artist.Name,
            Country = artist.Country,
            DateOfBirth = artist.DateOfBirth,
        }).ToList();

        return artistDTOs; 
    }

    public async Task<ArtistDTO?> GetByIdAsync(int id) {
        Artist? artist = await repository.GetByIdAsync(id);

        if (artist == null) {
            return null; 
        }

        ArtistDTO artistDTO = new() { 
            Id = artist.Id,
            Name = artist.Name,
            Country = artist.Country,
            DateOfBirth = artist.DateOfBirth
        };

        return artistDTO; 
    }

    public async Task AddAsync(ArtistDTO artistDTO) {
        if (artistDTO != null) {
            Artist newArtist = new() {
                Id = artistDTO.Id,
                Name = artistDTO.Name,
                Country = artistDTO.Country,
                DateOfBirth = artistDTO.DateOfBirth,
            };
            await repository.AddAsync(newArtist);
        }
    }

    public async Task UpdateAsync(ArtistDTO artistDTO) {
        Artist? artistToUpdate = await repository.GetByIdAsync(artistDTO.Id);

        if (artistToUpdate != null) {
            artistToUpdate.DateOfBirth = artistDTO.DateOfBirth;
            artistToUpdate.Name = artistDTO.Name;
            artistToUpdate.Country = artistDTO.Country;
            
            await repository.UpdateAsync(artistToUpdate);
        }
    }

    public async Task DeleteAsync(int id) => await repository.DeleteAsync(id);


}
