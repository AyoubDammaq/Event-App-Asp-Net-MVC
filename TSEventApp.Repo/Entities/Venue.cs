using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TSEventApp.Core.Base;

namespace TSEventApp.Core.Entities
{
    public class Venue : Entity
    {
        [Display(Name = "Venue Name")]
        [Required(ErrorMessage = "Please enter the venue name.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please enter the venue location.")]
        [StringLength(100)]
        public string Location { get; set; }

        [Display(Name = "Manager Name")]
        [Required(ErrorMessage = "Please enter the manager's name.")]
        public string ManagerName { get; set; }

        [Display(Name = "Manager Phone Number")]
        [Required(ErrorMessage = "Please enter the manager's phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string ManagerPhoneNumber { get; set; }

        [Display(Name = "Maximum Capacity")]
        [Range(1, int.MaxValue, ErrorMessage = "Maximum capacity should be at least 1.")]
        public int MaxCapacity { get; set; }

        // Assuming there might be multiple events held at the venue
        [ForeignKey("VenueId")]
        public ICollection<Event> Events { get; set; }
    }
}