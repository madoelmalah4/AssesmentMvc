using AssesmentProject.Models;
using AssesmentProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssesmentProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext Db;

        public TaskController(AppDbContext db)
        {
            Db = db;
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Task = await Db.Tasks.Include(x => x.project).Include(x => x.teamMember).FirstOrDefaultAsync(x => x.TaskId == Id);

            TaskViewModel view = new TaskViewModel() 
            {
            DeadLine = Task.DeadLine,
            Description = Task.Description,
            Priority = Task.Priority,
            Project_Id = Task.Project_Id,
            Status = Task.Status,
            projects = await Db.Projects.ToListAsync(),
            teamMembers = await Db.TeamMembers.ToListAsync(),
            TaskId = Task.TaskId,
            TeamMember_Id = Task.TeamMember_Id,
            Title = Task.Title
            };

            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TaskViewModel view , int Id)
        {

            var Task = await Db.Tasks.Include(x => x.project).Include(x =>x.teamMember).FirstOrDefaultAsync(x => x.TaskId == Id);

            Task.Status = view.Status;
            Task.DeadLine = view.DeadLine;
            Task.Priority = view.Priority;
            Task.Project_Id = view.Project_Id;
            Task.TeamMember_Id = view.TeamMember_Id;
            Task.Title = view.Title;

            await Db.SaveChangesAsync();

            return RedirectToAction("Index" , "Project");
        }
    }
}
