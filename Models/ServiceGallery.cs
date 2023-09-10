using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Island.Models
{
    public class ServiceGallery
    {
        [Key]
        public int id { get; set; }


        [Display(Name = "Image Title")]
        public string title { get; set; }


        [Display(Name = "Image Path")]
        public string filePath { get; set; }

        // Foreign key 
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        
        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }
    }
}