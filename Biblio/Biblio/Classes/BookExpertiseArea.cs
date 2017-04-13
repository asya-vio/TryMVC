using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class BookExpertiseArea
    {
        public string Name;
        public List<Book> ListOfBook = new List<Book>();

        public BookExpertiseArea(string name)
        {
            this.Name = name;
        }

        public void AddBook(Book book)
        {
            ListOfBook.Add(book);
        }

        public void DeleteBook(Book book)
        {

            for (int i = 0; i < ListOfBook.Count; i++)
            {
                if (ListOfBook[i].Name == book.Name)
                {
                    if (ListOfBook[i].Author.SequenceEqual(book.Author))
                    {
                        ListOfBook.RemoveAt(i);
                        return;
                    }

                }
            }
            return;
        }
    }
}
