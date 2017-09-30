namespace DemoMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoMVC.Models.PhotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DemoMVC.Models.PhotoContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Photos.AddOrUpdate(
                p => p.PhotoID,
                new Models.Photo { PhotoID = new Random().Next(1, 100000), CreateDate = DateTime.Now, Description = "Hola" });
            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
