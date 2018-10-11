using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRBadging.Models.Badging
{
    public class Terminate
    {
        [Key]
        [MaxLength(25)]
        public string UpId { get; set; }
        public string BadgeId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateJobTermination { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime BadgeTerminationDate { get; set; }
        public bool BadgeReturned { get; set; }

        
        public Badge Badge { get; set; }
    }
}