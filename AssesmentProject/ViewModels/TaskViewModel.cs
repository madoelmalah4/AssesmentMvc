using AssesmentProject.Models;
using System.ComponentModel.DataAnnotations;

namespace AssesmentProject.ViewModels
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime? DeadLine { get; set; }
        public int Project_Id { get; set; }
        public int TeamMember_Id { get; set; }
        public List<Project> ? projects { get; set; }
        public List<TeamMember> ? teamMembers {  get; set; }
    }
}
