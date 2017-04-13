using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class LibraryDepartment : ItemLender
    {
        int IDLibraryDepartment;

        public LibraryDepartment(ItemLenderBase dataBase, int IDLibraryDepartment) : base (dataBase)
        {
            this.DataBase = dataBase;

            this.IDLibraryDepartment = IDLibraryDepartment;

            LendedItem = new List<ItemLending>();

        }

    }
}
