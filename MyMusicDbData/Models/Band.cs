using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusicDbData.Models;

public class Band : Entity {
    public string? BandName { get; set; }
    public string? Country { get; set; }
    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }
    public ICollection<Artist>? Members { get; set; }
    public ICollection<Album>? Albums { get; set; }
    public ICollection<Track>? Singles { get; set; }
}
