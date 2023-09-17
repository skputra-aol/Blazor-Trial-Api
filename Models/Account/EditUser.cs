using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Account
{
    public class EditUser
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string email { get; set; }

        [MinLength(6, ErrorMessage = "The password field must be a minimum of 6 characters")]
        public string password { get; set; }

        public EditUser() { }

        public EditUser(User user)
        {
            firstName = user.firstName;
            lastName = user.lastName;
            email = user.email;
        }
    }
}