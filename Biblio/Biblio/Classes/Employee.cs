using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Employee : Man
    {
        public int EmployeeNumber { get; set; }
        public string Job { get; set; }

        public TeacherPass Pass { get; set; }

        public Employee(string lastname, string name, string secondname, string adress, string phonenumber,
            int EmployeeNumber, string Job)
            : base(lastname, name, secondname, adress, phonenumber)
        {
            this.EmployeeNumber = EmployeeNumber;
            this.Job = Job;
        }
    }
}
