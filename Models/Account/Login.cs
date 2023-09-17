using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Account
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}