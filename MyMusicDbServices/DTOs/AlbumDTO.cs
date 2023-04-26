using MyMusicDbData.Models;

namespace MyMusicDbServices.DTOs;

public class AlbumDTO {
    public int Id { get; set; } 
    public string? Name { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<int>? TrackIds { get; set; }
    public List<int>? ArtistIds { get; set; }
}
