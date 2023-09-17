using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Account
{
    public class ChangePassword
    {
        [Required]
        public string oldPassword { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The password field must be a minimum of 8 characters")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Passwords must be contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("newPassword", ErrorMessage = "Password and Repeat Password must match.")]
        public string repeatPassword { get; set; }
    
    }
}