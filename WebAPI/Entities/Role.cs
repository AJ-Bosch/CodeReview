﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Role
    {
        [Key]
        public required int RoleId { get; set; }
        public string? RoleName { get; set; }
        public int? AccessLevel { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false
    }
}
