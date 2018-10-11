using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRBadging.Models.Badging
{
    public class Employee
    {
        [Key]
        [MaxLength(25)]
        public string EmployeeId { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }

        public string BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}