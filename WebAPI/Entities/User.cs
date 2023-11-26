using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class User
    {
        [Key]
        public required int UserId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? CompanyCode { get; set; }
        public DateTime? LastUpdate { get; set; }
        // Navigation properties
        public required Role Role { get; set; }
        public required Company Company { get; set; }
    }
}
