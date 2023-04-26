namespace MyMusicDbServices.DTOs;

public class TrackDTO {
    public int Id { get; set; }
    public string Title { get; set; } = null!; //cannot be null 
    public DateTime? ReleaseDate { get; set; }
}
