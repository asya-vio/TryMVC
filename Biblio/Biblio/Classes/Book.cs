using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Book
    {
        public string Name;
        public string Author;
        public List<BookExemplar> ListOfExemplar = new List<BookExemplar>();

        public Book(string name, string author)
        {
            Name = name;
        }

        public void AddExemplar(int PublicationDate, int InventoryNumber)
        {
            ListOfExemplar.Add(new BookExemplar(PublicationDate, InventoryNumber));
        }

        public void DeleteExemplar(int InventoryNumber)
        {
            for (int i = 0; i < ListOfExemplar.Count; i++)
            {
                if (ListOfExemplar[i].InventoryNumber == InventoryNumber)
                {
                    ListOfExemplar.RemoveAt(i);
                    break;
                }
            }
        }

        public List<BookExemplar> ShowExemplars()
        {
            return ListOfExemplar; 
        }

        public List<BookExemplar> ShowFreeExemplars()
        {
            List<BookExemplar> resultList = new List<BookExemplar>();
            foreach (BookExemplar bookEx in ListOfExemplar)
            {
                if (bookEx.Presence == Item.presence.yes) resultList.Add(bookEx);
            }
            return resultList;          
        }
        
    }
}
