using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Island.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter your last name")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please enter your username")]

        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "Email Address")] 
        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Country")]
        public string Country { get; set; }


        [Display(Name = "City")]
        public string City { get; set;}


        [Display(Name = "Gender")]
        public string Gender { get; set; }

        //Users can upload many places
        public virtual ICollection<Place> UserPlaces { get; set; }

        //Users can upload many images
        //public virtual ICollection<PlaceGallery> PlaceGalleries { get; set; }

        //Users can upload many services
        public virtual ICollection<Service> UserServices { get; set; }
        //Users can upload many images
        //public virtual ICollection<ServiceGallery> ServiceGalleries { get; set; }


        //Users can have many favorites
        public virtual ICollection<Favorite> UserFavorites { get; set; }

    }
}