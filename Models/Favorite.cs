using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Island.Models
{
    public class Favorite
    {
        [Key]
        public int id { get; set; }

        // Foreign key for user 
        [Required(ErrorMessage = "Please enter UserId")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User Person { get; set; }

        // Foreign key for favorite Places
        public int? PlaceId { get; set; }
        [ForeignKey(nameof(PlaceId))]
        public Place Location { get; set; }

        // Foreign key for favorite Services
        public int? ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

    }
}