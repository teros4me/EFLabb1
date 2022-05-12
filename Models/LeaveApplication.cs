using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFlabb1.Models
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        public int EmployeeId { get; set; }

        public Employees Employee { get; set; }
    }
}
