using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class UserDto
    {        
        [Key]
        public required int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? CompanyCode { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool IsDeleted { get; set; } = false; // Default value is false
        // Navigation properties
        public required Role Role { get; set; }
        public required Company Company { get; set; }
    }
}
