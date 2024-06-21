using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels;

public class AddJobViewModel
{

    [Required(ErrorMessage = "Job name is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Employer is required.")]
    public int EmployerId { get; set; }
    public List<SelectListItem>? Employers { get; set; }

    public AddJobViewModel(List<Employer> employers)
    {
        Employers = new List<SelectListItem>();

        foreach(var employer in employers)
        {
            Employers.Add(
                new SelectListItem
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString()
                }
            );
        }
    }


    public AddJobViewModel()
    {

    }

}
