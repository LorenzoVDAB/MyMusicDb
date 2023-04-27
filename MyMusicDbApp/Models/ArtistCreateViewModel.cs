using System.ComponentModel.DataAnnotations;

namespace MyMusicDbApp.Models;

public class ArtistCreateViewModel {
    [StringLength(45, ErrorMessage = "Name needs to be shorter than 45 characters")]
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    [StringLength(45, ErrorMessage = "Country needs to be shorter than 45 characters")]
    public string? Country { get; set; }
    [DataType(DataType.Date)] 
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }
    public bool DateOfBirthKnown { get; set; } 
}
