using MyApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetBook();
        Book GetBookById(int id);
        List<String> AddBook( Book book);
    }
}
