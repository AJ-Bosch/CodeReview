using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Project
    {
        [Key]
        public required int ProjectId { get; set; }
        public required string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CompanyCode { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false
        // Navigation property
        public required Company Company { get; set; }
    }
}
