namespace MyMusicDbData.Models;

public class Track : Entity {
    public string Title { get; set; } = null!; 
    public DateTime? ReleaseDate { get; set; } 
}
