using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class InspectionImage
    {
        [Key]
        public required int ImageId { get; set; }
        public required int HeaderId { get; set; }
        public required string ImageUrl { get; set; }
        public DateTime? UploadDate { get; set; }
        // Navigation property
        public required InspectionHeader InspectionHeader { get; set; }
    }
}
