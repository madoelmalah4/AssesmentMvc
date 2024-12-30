using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssesmentProject.Models
{
    public class Task
    {
        [Key]
        public int TaskId {  get; set; }
        [MaxLength(100)]
        public string? Title {  get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority {  get; set; }
        public DateTime ? DeadLine {  get; set; }
        public int Project_Id { get; set; }
        public int TeamMember_Id {  get; set; }
        [ForeignKey("Project_Id")]
        public Project? project { get; set; }
        [ForeignKey("TeamMember_Id")]
        public TeamMember ? teamMember {  get; set; }
    }

}
