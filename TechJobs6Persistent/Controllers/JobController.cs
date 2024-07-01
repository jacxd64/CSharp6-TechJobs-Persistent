using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;
        private readonly ILogger<JobController> _logger;

        public JobController(JobDbContext dbContext, ILogger<JobController> logger)
        {
            context = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();
            return View(jobs);
        }

        public IActionResult Add()
        {
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers);
            return View(addJobViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            _logger.LogInformation("Add action hit");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid");
                Employer employer = context.Employers.Find((int)addJobViewModel.EmployerId);

                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    Employer = employer,
                    EmployerId = (int)addJobViewModel.EmployerId
                };

                context.Jobs.Add(newJob);
                context.SaveChanges();
                _logger.LogInformation("Job added successfully");
                return Redirect("/Job");
            }

            // Log ModelState errors
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
    }

            _logger.LogWarning("Model is invalid");
            List<Employer> employers = context.Employers.ToList();
            addJobViewModel.Employers = employers.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            return View(addJobViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();
            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);
            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);
            return View(jobDetailViewModel);
        }
    }
}
