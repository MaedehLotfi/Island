using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Island.Models
{
    public class PlaceReview
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please rate this place")]
        [Display(Name = "Rate this place")]
        public int rate { get; set; }

        [Required(ErrorMessage = "Please enter the title")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Review")]
        public string review { get; set; }

        // Foreign key 
        public int PlaceId { get; set; }
        [ForeignKey(nameof(PlaceId))]
        public Place Location { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }

    }
}