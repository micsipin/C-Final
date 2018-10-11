using HRBadging.Models.Badging;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace HRBadging.Data
{
    public class DummyData
    {
        public static List<Badge> GetBadges()
        {
            List<Badge> Badges = new List<Badge>()
            {
                new Badge()
                {
                    BadgeId = "2558MOH64",
                    EmployeeId = "92323425",
                    BadgeExp = DateTime.ParseExact("05/2010", "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    HasCustomSeal = true,
                    CustomSealExp = DateTime.ParseExact("09/2018", "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SITA = "Blue"
                },
                new Badge()
                {
                    BadgeId = "255MART7Z",
                    EmployeeId = "92301885",
                    BadgeExp = DateTime.ParseExact("04/20/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    HasCustomSeal = false,
                    CustomSealExp = DateTime.ParseExact("04/21/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SITA = "Blue"
                },
                new Badge()
                {
                    BadgeId = "255CAMP88",
                    EmployeeId = "92379656",
                    BadgeExp = DateTime.ParseExact("12/31/2017", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    HasCustomSeal = true,
                    CustomSealExp = DateTime.ParseExact("01/01/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SITA = "Red"
                },
                new Badge()
                {
                    BadgeId = "255SMT21A",
                    EmployeeId = "92312294",
                    BadgeExp = DateTime.ParseExact("07/02/2017", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    HasCustomSeal = false,
                    CustomSealExp = DateTime.ParseExact("07/05/2017", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SITA = "Blue"
                }

            };

            return Badges;
        }
        public static List<Employee> GetEmployees(BadgingContext context)
        {
            List<Employee> Employees = new List<Employee>()
                {
                    new Employee
                    {
                        EmployeeId = "92323425",
                        LName = "Mohammad",
                        FName = "Samual",
                        BadgeId = context.Badges.Find("2558MOH64").BadgeId

                    },
                    new Employee
                    {

                        EmployeeId = "92301885",
                        LName = "Martenez",
                        FName = "Juan",
                        BadgeId = context.Badges.Find("255MART7Z").BadgeId
                    },
                    new Employee
                    {
                        EmployeeId = "92379656",
                        LName = "Campango",
                        FName = "Boyette",
                        BadgeId = context.Badges.Find("255CAMP88").BadgeId
                    },
                    new Employee
                    {
                        EmployeeId = "92312294",
                        LName = "Smith",
                        FName = "Jessica",
                        BadgeId = context.Badges.Find("255SMT21A").BadgeId
                    }
                };
            context.SaveChanges();
            return Employees;
        }
        public static List<Terminate> GetTerminates(BadgingContext context)
        {
            List<Terminate> Terminates = new List<Terminate>()
            {
                new Terminate
                {
                    UpId = "92323425",
                    BadgeId = "2558MOH64",
                    DateJobTermination = DateTime.ParseExact("06/27/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeTerminationDate = DateTime.ParseExact("07/08/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeReturned = true
                },
                new Terminate
                {
                    UpId = "92301885",
                    BadgeId = "255MART7Z",
                    DateJobTermination = DateTime.ParseExact("01/27/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeTerminationDate = DateTime.ParseExact("02/08/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeReturned = true
                },
                new Terminate
                {
                    UpId = "92379656",
                    BadgeId = "255CAMP88",
                    DateJobTermination = DateTime.ParseExact("09/27/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeTerminationDate = DateTime.ParseExact("10/03/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeReturned = true
                },
                new Terminate
                {
                    UpId = "92312294",
                    BadgeId = "255SMT21A",
                    DateJobTermination = DateTime.ParseExact("03/21/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeTerminationDate = DateTime.ParseExact("10/01/2018", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    BadgeReturned = false
                }
            };
            context.SaveChanges();
            return Terminates;

        }
    }
}

