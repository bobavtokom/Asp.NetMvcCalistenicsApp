using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Calistenics.Models {
    public class AppDbContext : DbContext {
        public DbSet<Excercise> Excercises { get; set; }
        public AppDbContext() : base("name=Gimnastics") {
        }

    }
}