using Microsoft.EntityFrameworkCore;

namespace AssesmentProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> ? Projects {  get; set; }
        public DbSet<TeamMember> ? TeamMembers {  get; set; }
        public DbSet<Task> ? Tasks {  get; set; }

    }
}
