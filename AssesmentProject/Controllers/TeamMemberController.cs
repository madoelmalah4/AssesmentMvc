using AssesmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssesmentProject.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext Db;

        public TeamMemberController(AppDbContext db)
        {
            Db = db;
        }

        public async Task<IActionResult> Index()
        {
            var teammeber = await Db.TeamMembers.ToListAsync();
            return View(teammeber);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var TeamMember = await Db.TeamMembers.Include(x => x.Tasks).ThenInclude(x =>x.project).FirstOrDefaultAsync(x => x.TeamMemberID == Id);
            return View(TeamMember);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var TeamMember = await Db.TeamMembers.FindAsync(Id);
            return View(TeamMember);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeamMember member,int Id)
        {
            var TeamMember = await Db.TeamMembers.FindAsync(Id);

            TeamMember.TeamMemberName = member.TeamMemberName;
            TeamMember.TeamMemberRole = member.TeamMemberRole;
            TeamMember.TeamMemberEmail = member.TeamMemberEmail;

            await Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var TeamMember = await Db.TeamMembers.FindAsync(Id);
            return View(TeamMember);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int Id)
        {
            var TeamMember = await Db.TeamMembers.FindAsync(Id);
            Db.TeamMembers.Remove(TeamMember);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}
