using System.ComponentModel.DataAnnotations;

namespace Agri_Energy.Models
{
    public class LoginViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserType { get; set; } // "Farmer" or "Employee"
    }
}
