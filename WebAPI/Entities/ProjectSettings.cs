using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class ProjectSettings
    {
        [Key]
        public required int SettingId { get; set; }
        public int ProjectId { get; set; }
        public bool? GpsAssetSearch { get; set; }
        public bool? Maps { get; set; }
        public bool? LocationTracking { get; set; }
        public int? MaxDistanceFromAsset { get; set; }
        public DateTime? TrackingStartTime { get; set; }
        public DateTime? TrackingEndTime { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false

        // Navigation property
        public required Project Project { get; set; }
    }
}
