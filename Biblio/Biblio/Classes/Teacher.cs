using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Teacher : Man
    {
        public int TeacherNumber { get; set; }
        public string Faculty { get; set; }
        public string Job { get; set; }

        public TeacherPass Pass { get; set; }

        public Teacher(string lastName, string name, string secondName, string address, string phoneNumber,
            int TeacherNumber, string Faculty, string Job)
            : base(lastName, name, secondName, address, phoneNumber)
        {

            this.TeacherNumber = TeacherNumber;
            this.Faculty = Faculty;
            this.Job = Job;
        }
    }
}
