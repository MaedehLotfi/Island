using Island.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Island.Models
{
    public class Service
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [Display(Name = "Service's Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Phone Number II")]
        public string TellNumber { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "Website/Social Page")]
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

        //Services can have many images
        public virtual ICollection<ServiceGallery> ServiceGalleries { get; set; }

        //Services can have many reviews
        public virtual ICollection<ServiceReview> ServiceReviews { get; set; }
    }
}