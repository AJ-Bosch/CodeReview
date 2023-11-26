﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class InspectionClass
    {
        [Key]
        public required int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? Description { get; set; }
    }
}
