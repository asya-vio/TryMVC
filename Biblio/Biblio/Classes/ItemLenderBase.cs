using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class ItemLenderBase
    {
        public string LenderExpertiseArea { get; set; }

        public BookCatalog Catalog { get; set; }

        public List<StudentPass> Students = new List<StudentPass>();

        public List<TeacherPass> Teachers = new List<TeacherPass>();

        public List<Employee> Employees = new List<Employee>();

        public ItemLenderBase(BookCatalog Catalog, string ExpArea)
        {
            LenderExpertiseArea = ExpArea;

            this.Catalog = Catalog;

        }

        public void AddStudentPass (StudentPass pass)
        {
            Students.Add(pass);
        }

        public void DeleteStuddentPass (int IDPass)
        {
            foreach (StudentPass studentPass in Students)
            {
                if (studentPass.IDPass == IDPass)
                {
                    Students.Remove(studentPass);
                    return;
                }
            }
        }

        public void AddTeacherPass(TeacherPass pass)
        {
            Teachers.Add(pass);
        }

        public void DeleteTeacherPass(int IDPass)
        {
            foreach (TeacherPass teacherPass in Teachers)
            {
                if (teacherPass.IDPass == IDPass)
                {
                    Teachers.Remove(teacherPass);
                    return;
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void DeleteEmployee(int EmployeeNumber)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.EmployeeNumber == EmployeeNumber)
                {
                    Employees.Remove(employee);
                    return;
                }
            }
        }

    }
}
