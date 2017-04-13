using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class ItemLending
    {
        public int IDLending { get; set; }

        public DateTime LendingDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int IDLender { get; set; }

        public int EmployeeNumber { get; set; }

        public int IDPass { get; set; }

        public bool IsStudent { get; set; }

        public int InventoryNumber { get; set; }

        public ItemLending
            (int IDLending, DateTime LendingDate, int IDLender, int EmployeeNumber, 
            int IDPass, bool IsStud, int InventoryNumber)
        {
            this.IDLending = IDLending;

            this.LendingDate = LendingDate;

            //ReturnDate = LendDate;

            this.IDLender = IDLender;

            this.EmployeeNumber = EmployeeNumber;

            this.IDPass = IDPass;

            this.IsStudent = IsStud;

            this.InventoryNumber = InventoryNumber;
        }

    }
}
