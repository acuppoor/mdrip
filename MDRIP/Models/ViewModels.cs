using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDRIP.Models
{
    public class AdminModel
    {
        public IEnumerable<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles { get; set; }

        public IEnumerable<ApplicationUser> Accounts { get; set; }
    }

    public class CreateAccountAdminModel {
        public AdminRegisterViewModel Account { get; set; }

        public IEnumerable<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles { get; set; }
    }

    public class AdminRegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HouseAndStreet { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        [Required]
        [Display(Name = "Role of the User")]
        public string Role { get; set; }

        public bool Activated { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
