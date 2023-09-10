using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Island.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}