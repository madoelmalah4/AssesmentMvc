using AssesmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssesmentProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext Db;

        public ProjectController(AppDbContext db)
        {
            Db = db;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await Db.Projects.ToListAsync();
            return View(projects);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            await Db.Projects.AddAsync(project);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Project = await Db.Projects.FirstOrDefaultAsync(x=>x.ProjectId == Id);
            return View(Project);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project P,int Id)
        {
            var Project = await Db.Projects.FirstOrDefaultAsync(x => x.ProjectId == Id);

            Project.ProjectName = P.ProjectName;
            Project.ProjectDescription = P.ProjectDescription;
            Project.StartDate = P.StartDate;
            Project.EndDate = P.EndDate;

            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var Project = await Db.Projects.FirstOrDefaultAsync(x => x.ProjectId == Id);

            Db.Projects.Remove(Project);
            await Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int Id)
        {
            var Project = await Db.Projects.Include(x => x.Tasks).ThenInclude(x => x.teamMember).FirstOrDefaultAsync(x => x.ProjectId == Id);
            return View(Project);
        }




    }
}
