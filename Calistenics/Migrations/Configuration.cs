namespace Calistenics.Migrations
{
    using Calistenics.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Calistenics.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Calistenics.Models.AppDbContext context)
        {
            context.Excercises.AddOrUpdate(x => x.Name,
                new Excercise {
                    Name = "L sit",
                    Description = "great exercise for building strenght in arms , legs, abs, core",
                    Level = "Basic"
                },
                new Excercise {
                    Name = "Handstand",
                    Description = "acrobatic exercise that make you look cool, great for shoelder strength and balance",
                    Level = "Intermediate"
                });
        }
    }
}