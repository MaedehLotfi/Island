using Island.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Island.Models
{
    public class PlaceGallery
    {
        [Key]
        public int id { get; set; }

        
        [Display(Name = "Image Title")]
        public string title { get; set; }

        
        [Display(Name = "Image Path")]
        public string filePath { get; set; }

        // Foreign key 
        public int PlaceId { get; set; }
        [ForeignKey(nameof(PlaceId))]
        public Place Location { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }
    }
}