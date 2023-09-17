using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Organizers
{
    public class AddOrganizer
    {

        [Required]
        public string organizerName { get; set; }

        [Required]
        public string imageLocation { get; set; }


    }
}