using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class InspectionHeader
    {
        [Key]
        public required int HeaderId { get; set; }
        public int? CompanyCode { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public int? InspectionTypeId { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool? Pass { get; set; }
        public string? Comment { get; set; }
        // Navigation properties
        public required Company Company { get; set; }
        public required Project Project { get; set; }
        public required User User { get; set; }
        public required InspectionType InspectionType { get; set; }
    }
}
