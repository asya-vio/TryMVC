using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class BookCatalog
    {
        public List<BookExpertiseArea> ListOfExpertiseArea;

        public BookCatalog()
        {
            ListOfExpertiseArea = new List<BookExpertiseArea>();
        }

        public void AddExpertiseArea(string NameOfArea)
        {
            ListOfExpertiseArea.Add(new BookExpertiseArea(NameOfArea));
        }

        public void DeleteExpertiseArea(string name)
        {
            int i;
            for (i = 0; i < ListOfExpertiseArea.Count; i++)
            {
                if (ListOfExpertiseArea[i].Name == name)
                {
                    ListOfExpertiseArea.RemoveAt(i);
                    break;
                }
            }
            if (i == ListOfExpertiseArea.Count - 1)
                throw new ArgumentException();
        }

        private Book FindByAuthor(string authors)
        {
            for (int i = 0; i < ListOfExpertiseArea.Count; i++)
            {
                for (int j = 0; j < ListOfExpertiseArea[i].ListOfBook.Count; j++)
                {
                    if (ListOfExpertiseArea[i].ListOfBook[j].Author == authors)
                        return ListOfExpertiseArea[i].ListOfBook[j];
                }
            }
            throw new ArgumentException();
        }

        private Book FindByName(string name)
        {
            for (int i = 0; i < ListOfExpertiseArea.Count; i++)
            {
                for (int j = 0; j < ListOfExpertiseArea[i].ListOfBook.Count; j++)
                {
                    if (ListOfExpertiseArea[i].ListOfBook[j].Name == name)
                        return ListOfExpertiseArea[i].ListOfBook[j];
                }
            }
            throw new ArgumentException();
        }

    public Book FindBook(int choice, string authors, string name)
        {
            if (choice == 1)
            {
                var book = FindByName(name);
                return book;
            }
            else
            {
                var book = FindByAuthor(authors);
                return book;
            }
        }

        public List<BookExpertiseArea> Print()
        {
            return ListOfExpertiseArea;
        }
    }
}
