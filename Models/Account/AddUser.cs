using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Account
{
    public class AddUser
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The password field must be a minimum of 8 characters")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Passwords must be contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string password { get; set; }

        [Required(ErrorMessage = "Repeat password is required.")]
        [Compare("password", ErrorMessage = "password and Repeat password must match.")]
        public string repeatPassword { get; set; }

    }
}