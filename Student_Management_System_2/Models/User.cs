using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Student_Management_System_2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        
        public string UserLastName { get; set; }

        public string UserDepartment { get; set; }

     
        public string UserPassword { get; set; }
        public string? Username { get; set; }

      //  public List<string> UserModules { get; set; }

    }
}
