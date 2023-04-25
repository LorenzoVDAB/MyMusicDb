namespace MyMusicDbData.Models;

public class Artist : Entity {
    public string? Name { get; set; }
    public ICollection<Album>? Albums { get; set; } 
    public ICollection<Track>? Singles { get; set; } 
}