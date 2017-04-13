using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class BookCatalog
    {
        public List<Book> ListOfBook = new List<Book>();

        public BookCatalog() { }


        private Book FindByAuthor(string authors)
        {
            for (int i = 0; i < ListOfBook.Count; i++)
            {
                if (ListOfBook[i].Author == authors)
                    return ListOfBook[i];
            }
            throw new ArgumentException();
        }

        private Book FindByName(string name)
        {
            for (int i = 0; i < ListOfBook.Count; i++)
            {
                if (ListOfBook[i].Name == name)
                    return ListOfBook[i];

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
                    if (ListOfBook[i].Author == book.Author)
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
