using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calistenics.Models {
    public class Excercise {
        public int Id { get; set; }
        [Required]
        public string Name { get; set;}
        [StringLength(200, ErrorMessage = "please insert minimum 6  up to 200 characters", MinimumLength = 6)]  
        public string Description { get; set;}
        public string Level { get; set;}
        [Url(ErrorMessage = "Invalid URL format. Please include 'http://' or 'https://'")]
        public string Url { get; set; }
    }
}