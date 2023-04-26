using MyMusicDbData.Models;
using MyMusicDbData.Repositories.Interfaces;
using MyMusicDbServices.DTOs; 

namespace MyMusicDbServices; 

public class TracksService {
    private readonly ITracksRepository repository; 

    public TracksService(ITracksRepository repository) {
        this.repository = repository; 
    }
    
    public async Task<List<AlbumDTO>?> GetAlbumsFromIdsAsync(List<int> Ids) {
        //Get all the albums from the repository using the Ids List 
        List<Album>? albums = await repository.GetAlbumsFromIdsAsync(Ids);
        //Create a new list for the DTOs 
        List<AlbumDTO>? albumDTOs = new(); 

        if (albums != null) {
            //Create a new AlbumDTO for each Album in the list of albums 
            albumDTOs = albums.Select(a => new AlbumDTO() {
                Id = a.Id,
                Name = a.Title,
                ReleaseDate = a.ReleaseDate,
                ArtistIds = a.Artists?.Select(artist => artist.Id)?.ToList(),
                TrackIds = a.Tracks?.Select(track => track.Id)?.ToList()
            }).ToList();
        }

        return albumDTOs; 
    }

    public async Task<List<TrackDTO>?> GetTracksFromIdsAsync(List<int> Ids) {
        //Get all the tracks from the repository using the Ids List 
        List<Track>? tracks = await repository.GetTracksFromIdsAsync(Ids);
        //Create a new list for the DTOs 
        List<TrackDTO>? trackDTOs = new();

        if (tracks != null) {
            //Create a new AlbumDTO for each Album in the list of albums 
            trackDTOs = tracks.Select(a => new TrackDTO() {
                Id = a.Id,
                Title = a.Title,
                ReleaseDate = a.ReleaseDate
            }).ToList();
        }

        return trackDTOs;
    }
}

