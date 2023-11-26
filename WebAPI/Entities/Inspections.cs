using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Inspections
    {
        [Key]
        public required int InspectionCheckId { get; set; }
        public int? InspectionTypeId { get; set; }
        public required string Content { get; set; }
        public int? ClassId { get; set; }

        // Navigation properties
        public required InspectionType InspectionType { get; set; }
        public required InspectionClass InspectionClass { get; set; }
    }
}
