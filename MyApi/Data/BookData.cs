using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Data
{
    public class BookData
    {
        private static List<Book> _bookList;
        public BookData()
        {
            _bookList = new List<Book>();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookList;
        }

        public Book GetBookByID(int id)
        {
           return _bookList.Find((x) => x.Id == id);
        }

        public bool AddNewBook(Book book)
        {
            _bookList.Add(book);
            return true;
        }
    }
}
