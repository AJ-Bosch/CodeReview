﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Asset
    {
        [Key]
        public required Guid AssetId { get; set; }
        public string? AssetRef { get; set; }
        public int? ProjectId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false
        // Navigation property
        public required Project Project { get; set; }
    }
}
