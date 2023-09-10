using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Island.Models
{
    public class Place
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the Latitude")]
        [Display(Name = "Latitude")]
        public string latG { get; set; }

        [Required(ErrorMessage = "Please enter the Longitude")]
        [Display(Name = "Longitude")]
        public string longG { get; set; }

        [Required(ErrorMessage = "Please enter the Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Phone Number II")]
        public string TellNumber { get; set; }


        [Display(Name = "Opennig Hour")]
        public string OpennigHour { get; set; }


        [Display(Name = "More Info")]
        public string MoreInfo { get; set; }


        [Display(Name = "Instagram Page")]
        public string Instagram { get; set; }

        [Display(Name = "Website Page")]
        public string Website { get; set; }

        // Foreign key 
        [Required(ErrorMessage = "Please enter UserId")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }

        // Foreign key for category
        public int? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        //Places can have many images
        public virtual ICollection<PlaceGallery> PlaceGalleries { get; set; }

        //Places can have many reviews
        public virtual ICollection<PlaceReview> PlaceReviews { get; set; }
    }
}