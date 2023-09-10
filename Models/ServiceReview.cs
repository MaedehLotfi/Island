using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Island.Models
{
    public class ServiceReview
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please rate this service")]
        [Display(Name = "Rate this service")]
        public int rate { get; set; }

        [Required(ErrorMessage = "Please enter the title")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Review")]
        public string review { get; set; }

        // Foreign key 
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }
    }
}