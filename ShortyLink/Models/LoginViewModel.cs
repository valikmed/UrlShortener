using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UrlShortener.Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public IdentityUser Email { get; internal set; }
    }

}

