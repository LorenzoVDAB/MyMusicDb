using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusicDbData.Models;

public class Track : Entity {
    public string Title { get; set; } = null!; //Cannot be null 
    [Column(TypeName = "date")]
    public DateTime? ReleaseDate { get; set; } 
    public ICollection<Artist>? Artists { get; set; }
    public Band? Band { get; set; }
    public Album? Album { get; set; }
}
