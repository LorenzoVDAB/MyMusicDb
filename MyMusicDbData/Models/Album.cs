using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusicDbData.Models;

public class Album : Entity {
    public string? Title { get; set; }
    [Column(TypeName = "date")]
    public DateTime? ReleaseDate { get; set; }
    public ICollection<Track>? Tracks { get; set; }
    public ICollection<Artist>? Artists { get; set; }
    public Band? Band { get; set; } 
}
