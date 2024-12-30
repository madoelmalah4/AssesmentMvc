using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AssesmentProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId {  get; set; }
        [MaxLength(100)]
        public required string? ProjectName { get; set; }
        [MaxLength(500)]
        public string? ProjectDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Task>? Tasks { get; set; }

    }
}
