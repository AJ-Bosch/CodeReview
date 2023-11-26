using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class InspectionClass
    {
        [Key]
        public required int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false
    }
}
