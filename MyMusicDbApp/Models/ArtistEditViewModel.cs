using System.ComponentModel.DataAnnotations;

namespace MyMusicDbApp.Models;

public class ArtistEditViewModel : IValidatableObject {
    public int Id { get; set; }
    [StringLength(45)]
    [Required]
    public string? Name { get; set; }
    [StringLength(45)]
    public string? Country { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }
    public bool DateOfBirthKnown { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
        List<ValidationResult> validationResults = new();

        if (String.IsNullOrEmpty(Name)) {
            validationResults.Add(new ValidationResult("Name should not be empty."));
        }

        return validationResults; 
    }
}
