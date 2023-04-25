namespace MyMusicDbData.Models;

public class Album : Entity {
    public string? Name { get; set; } 
    public DateTime? ReleaseDate { get; set; }
    public ICollection<Track>? Tracks { get; set; }
    public ICollection<Artist>? Artists { get; set; }
}
