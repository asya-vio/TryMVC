using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class ReadingHall  : ItemLender
    {
        int IDReadingHall;

        public ReadingHall(ItemLenderBase dataBase, int IDReadingHall) : base (dataBase)
        {
     
            this.DataBase = dataBase;

            this.IDReadingHall = IDReadingHall;

            LendedItem = new List<ItemLending>();

        }
    }
}
