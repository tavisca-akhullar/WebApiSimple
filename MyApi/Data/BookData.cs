using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MyApi.Data
{
    public class BookData
    {
        private static List<Book> _bookList = new List<Book>();

        
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

        public bool UpdateBook(int id,Book value)
        {
            for(int i=0;i<_bookList.Count;i++)
            {
                if (_bookList[i].Id==id)
                {
                    _bookList[i] = value;
                    return true;
                }
            }
            return false;
        }


        public bool DeleteBook(int id)
        {
            for (int i = 0; i < _bookList.Count; i++)
            {
                if (_bookList[i].Id == id)
                {
                    _bookList.Remove(_bookList[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
