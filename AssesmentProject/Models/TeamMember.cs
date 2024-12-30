using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace AssesmentProject.Models
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberID { get; set; }
        [MaxLength(100)]
        public required string? TeamMemberName { get; set; }
        [MaxLength(100)]
        public required string ? TeamMemberEmail { get; set; }
        [MaxLength(50)]
        public string ? TeamMemberRole { get; set; }
        public List<Task> ? Tasks {  get; set; }
    }
}
