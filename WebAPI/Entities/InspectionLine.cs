using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class InspectionLine
    {
        [Key]
        public required int LineId { get; set; }
        public int? HeaderId { get; set; }
        public int? CheckId { get; set; }
        public bool? ResultBoolean { get; set; }
        public string? ResultText { get; set; }
        public int? ResultDropdown { get; set; }
        // Navigation property
        public required InspectionHeader InspectionHeader { get; set; }
    }
}
