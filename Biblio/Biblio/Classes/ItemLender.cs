using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class ItemLender
    {
        public int IDLender;

        public List<ItemLending> LendedItem;

        public ItemLenderBase DataBase;

        public ItemLender(ItemLenderBase dataBase)
        {
            this.DataBase = dataBase;

            LendedItem = new List<ItemLending>();
        }

        public void LandItem(int ID, DateTime LendingDate, int IDLender, int EmployeeNumber, int IDPass, bool IsStudent, int InventoryNumber)
        {
            ItemLending itemLending = new ItemLending(ID, LendingDate, IDLender, EmployeeNumber, IDPass, IsStudent, InventoryNumber);

        }

        public void GetItem(int InventoryNumber, int IDPass, DateTime ReturnDate)
        {
            for (int i = 0; i < LendedItem.Count; i++)
            {
                if (LendedItem[i].InventoryNumber == InventoryNumber && LendedItem[i].IDPass == IDPass)
                {
                    LendedItem[i].ReturnDate = ReturnDate;
                    //LendedItem.RemoveAt(i);
                    break;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            return;
        }

        public List<BookExemplar> ShowLandedItem(int IDPass)
        {

            // ищем все Landing'и с указанным ID и типом

            List<ItemLending> itemLendingList = new List<ItemLending>();

            foreach (ItemLending lending in LendedItem)
            {
                if (lending.IDPass == IDPass)
                {
                    itemLendingList.Add(lending);
                }
            }

            // ищем книги, у которых есть экземляры с инвентарным номером выдачи

            List<BookExemplar> resultList = new List<BookExemplar>();


            foreach (Book book in DataBase.Catalog.ListOfBook)
            {
                foreach (BookExemplar bookExemplar in book.ListOfExemplar)
                {

                    foreach (ItemLending item in itemLendingList)
                    {
                        if (item.InventoryNumber == bookExemplar.InventoryNumber)
                        {
                            resultList.Add(bookExemplar);
                        }
                    }

                }
            }

            return resultList;

        }
    }
}
