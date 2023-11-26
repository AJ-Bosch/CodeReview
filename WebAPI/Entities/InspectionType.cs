using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class InspectionType
    {
        [Key]
        public int InspectionTypeId { get; set; }
        public string? InspectionTypeName { get; set; }
        public string? Description { get; set; }
        public int? ProjectId { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false
        // Navigation property
        public Project? Project { get; set; }
    }
}
