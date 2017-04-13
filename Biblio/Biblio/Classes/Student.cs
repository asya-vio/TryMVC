using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Student : Man
    {
        public int IDStudentCard { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }

        public StudentPass Pass { get; set; }

        public Student (string lastName, string name, string secondName, string address, string phoneNumber,
            int IDStudentCard, string Faculty, int Course)
            : base(lastName, name, secondName, address, phoneNumber)
        {

            this.IDStudentCard = IDStudentCard;
            this.Faculty = Faculty;
            this.Course = Course;
        }
        
    }
}
