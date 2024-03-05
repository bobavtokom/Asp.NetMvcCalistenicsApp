﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calistenics.Models {
    public class Excercise {
        public int Id { get; set; }
        [Required]
        public string Name { get; set;}
        public string Description { get; set;}
        public string Level { get; set;}
    }
}