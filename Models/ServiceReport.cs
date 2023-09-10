using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Island.Models
{
    public class ServiceReport
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter the title for your Report")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Message")]
        public string message { get; set; }


        // Foreign key 
        public int ServiceReviewId { get; set; }
        [ForeignKey(nameof(ServiceReviewId))]
        public ServiceReview ServiceReview { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }
    }
}