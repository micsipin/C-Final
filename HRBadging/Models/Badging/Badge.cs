using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRBadging.Models.Badging
{
    public class Badge
    {
        [Key]
        [MaxLength(25)]
        public string BadgeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BadgeExp { get; set; }
        public bool? HasCustomSeal { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CustomSealExp { get; set; }
        public string SITA { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public List<Employee> Employees { get; set; }
    }
}