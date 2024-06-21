using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels;

public class AddEmployerViewModel
{
    [Required(ErrorMessage ="Please add a name")]
    public string? Name { get; set; }

    [Required(ErrorMessage ="Please add a location")]
    public string? Location { get; set; }



}
