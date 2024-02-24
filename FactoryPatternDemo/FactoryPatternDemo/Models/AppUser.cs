using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FactoryPatternDemo.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(50)]
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        public String? Address { get; set; }
    }
}
