using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Island.Models
{
    public class PlaceReport
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter the title for your Report")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Message")]
        public string message { get; set; }


        // Foreign key 
        public int PlaceReviewId { get; set; }
        [ForeignKey(nameof(PlaceReviewId))]
        public PlaceReview PlaceReview { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }
    }
}