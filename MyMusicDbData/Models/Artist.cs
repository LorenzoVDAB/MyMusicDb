using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMusicDbData.Models;

public class Artist : Entity {
    [Required]
    public string Name { get; set; }    
    public string? Country { get; set; }
    [Column(TypeName = "date")]
    public DateTime? DateOfBirth { get; set; } 
    public ICollection<Album>? Albums { get; set; }
    public ICollection<Track>? Singles { get; set; } 
    public ICollection<Band>? Bands { get; set; } 
}