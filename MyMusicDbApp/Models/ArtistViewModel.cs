using System.ComponentModel.DataAnnotations;

namespace MyMusicDbApp.Models;

public class ArtistViewModel {
    public int Id { get; set; } 
    public string? Name { get; set; }
    public string? Country { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
