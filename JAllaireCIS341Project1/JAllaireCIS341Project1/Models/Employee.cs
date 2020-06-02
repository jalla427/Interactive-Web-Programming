using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JAllaireCIS341Project1.Models
{
    public class Employee
    {
        //Keys
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
        public int RestaurantID { get; set; }

        //Properties
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //Navigation Properties
        public EmployeeRole EmployeeRole { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
