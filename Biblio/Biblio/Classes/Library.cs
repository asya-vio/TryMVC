using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Library
    {
        List<LibraryDepartment> ListLibraryDept;
        List<ReadingHall> ListReadingHall;

        public Library()
        {
            ListLibraryDept = new List<LibraryDepartment>();
            ListReadingHall = new List<ReadingHall>();
        }

        public void AddLibraryDept(BookCatalog bookCatalog, ItemLenderBase lenderBase, string ExpertiseArea, int IDLibraryDept)
        {
            ListLibraryDept.Add(new LibraryDepartment(lenderBase, IDLibraryDept));

        }

        public void AddReadingHall(BookCatalog bookCatalog, ItemLenderBase lenderBase, string ExpertiseArea, int IDReadingHall)
        {
            ListReadingHall.Add(new ReadingHall(lenderBase, IDReadingHall));
        }

        //по идеее, для внесения в базу новых библиотек и читальных залов, тоже нужна своя форма с запросом, но ее нет, потому что некогда
        //на название области знаний, это для тестового варианта
    }
}
