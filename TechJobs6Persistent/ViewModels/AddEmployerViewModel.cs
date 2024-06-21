using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels;

public class AddEmployerViewModel
{
    [Required(ErrorMessage ="Please add a name")]
    [StringLength(50, MinimumLength =3, ErrorMessage ="Name should be between 3-50 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage ="Please add a location")]
    [StringLength(30, MinimumLength = 3, ErrorMessage ="Location should be between 3-30 characters")]
    public string? Location { get; set; }



}
