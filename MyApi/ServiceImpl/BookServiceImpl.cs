using MyApi.Data;
using MyApi.Service;
using MyApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.ServiceImpl
{
    public class BookServiceImpl:IBookService
    {
       private BookData _bookData;
       private BookValidator _validator;
        public BookServiceImpl()
        {
            _bookData = new BookData();
            _validator = new BookValidator();
        }

        public List<string> AddBook(Book book)
        {
            List<String> exceptions = _validator.Validate(book);
            if (exceptions.Count==0)
            {
                _bookData.AddNewBook(book);
            }
            return exceptions;
        }

        public IEnumerable<Book> GetBook()
        {
            return _bookData.GetBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookData.GetBookByID(id);
        }
    }
}
