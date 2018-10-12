namespace HRBadging.Migrations.HR
{
    using HRBadging.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRBadging.Data.BadgingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\HR";
        }

        protected override void Seed(HRBadging.Data.BadgingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Badges.AddOrUpdate(
                b => b.BadgeId, DummyData.GetBadges().ToArray());
            context.SaveChanges();

             
            context.Employees.AddOrUpdate(
              e => new { e.EmployeeId, e.LName, e.FName }, DummyData.GetEmployees(context).ToArray());
            context.SaveChanges();

            context.Terminates.AddOrUpdate(
                t => new { t.UpId, t.BadgeId, t.DateJobTermination, t.BadgeTerminationDate, t.BadgeReturned }, DummyData.GetTerminates(context).ToArray());
            context.SaveChanges();
        }
        }
    }

