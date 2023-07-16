using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_2.Models
{
     public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }

        public string Password { get; set; }
        public string? Username { get; set; }
    }
}
