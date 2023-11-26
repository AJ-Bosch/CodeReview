using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Company
    {
        [Key]
        public required int CompanyId { get; set; }
        public required string CompanyName { get; set; }
        public string? Address { get; set; }
        public int? ZipCode { get; set; }
        public string? Province { get; set; }
        public string? LogoURL { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
    }
}
