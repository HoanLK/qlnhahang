namespace QLNhaHang.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QLNhaHang.Models.DBQLNhaHang>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "QLNhaHang.Models.DBQLNhaHang";
        }

        protected override void Seed(QLNhaHang.Models.DBQLNhaHang context)
        {
            //  This method will be called after migrating to the latest version.

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
