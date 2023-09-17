using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Organizers
{
    public class EditOrganizer
    {
        [Required]
        public string organizerName { get; set; }

        [Required]
        public string imageLocation { get; set; }

        public EditOrganizer() { }
        public EditOrganizer(Organizer organizer)
        {
            organizerName = organizer.organizerName;
            imageLocation = organizer.imageLocation;
        }
    }
}