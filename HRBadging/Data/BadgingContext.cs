using HRBadging.Models.Badging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRBadging.Data
{
    public class BadgingContext : DbContext
    {
        public BadgingContext() : base("HRBadgingConnection")
        { }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Terminate> Terminates { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}