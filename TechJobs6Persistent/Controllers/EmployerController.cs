using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    { 
        private JobDbContext context;
        public EmployerController(JobDbContext dbContext)
        {
            context =dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        [HttpGet]
        [Route("Employer/create")]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer theEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                if (context.Employers.Any(e => e.Name == addEmployerViewModel.Name))
                {
                    return View("Create", addEmployerViewModel);
                }
                else
                {
                    context.Employers.Add(theEmployer);
                    context.SaveChanges();

                    return Redirect("/Employer");
                }
            }
            return View("Create", addEmployerViewModel);
        }

        [HttpGet]
        public IActionResult About(int id)
        {
            Employer theEmployer = context.Employers.Find(id);
            return View(theEmployer);
        }
    }
}

