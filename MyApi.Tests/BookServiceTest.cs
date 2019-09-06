using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MyApi.Service;
using MyApi.ServiceImpl;
using MyApi.Data;
using FluentAssertions;

namespace MyApi.Tests
{
  
   public class BookServiceTest
    {
        [Fact]
        public void Get_Null_List_When_No_Book_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            List<Book> books=(List<Book>)service.GetBook();
            Assert.Equal(0,books.Count);
        }


        [Fact]
        public void Get_List_When_BookList_Has_One_Book()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It", "William Shakespeare", "Suspense", 1000);
            service.AddBook(book);
            List<Book> books= (List<Book>)service.GetBook();
            Assert.Equal(book,books[0]);
        }

        [Fact]
        public void Get_List_When_BookList_Has_More_Than_One_Book()
        {
            IBookService service = new BookServiceImpl();
           List<Book> bookList = new List<Book>
                {
                new Book(1,"As You Like It","William Shakespeare","Suspense",1000)
                ,new Book(2,"Half Girlfirend","Chetan Bhagat","Romance",500)
                ,new Book(3,"Veronica Decides To Die","Paul Caulho","Thriller",800)
                };
            foreach (var book in bookList)
            {
                service.AddBook(book);
            }
            List<Book> books = (List<Book>)service.GetBook();
            books.Should().BeEquivalentTo(bookList);
        }

        [Fact]
        public void Add_Book_In_BookList()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It", "William Shakespeare", "Suspense", 1000);
            service.AddBook(book);
            List<Book> books = (List<Book>)service.GetBook();
            Assert.Equal(book, books[0]);
        }

        [Fact]
        public void Book_Doesnot_Get_Added_When_Invalid_Credentials_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It Part-2", "William12 Shakespeare", "Suspense", 1000);
            service.AddBook(book);
            List<Book> books = (List<Book>)service.GetBook();
            Assert.Equal(0, books.Count);
        }

        [Fact]
        public void Get_Book_By_Id()
        {
            IBookService service = new BookServiceImpl();
            List<Book> bookList = new List<Book>
                {
                new Book(1,"As You Like It","William Shakespeare","Suspense",1000)
                ,new Book(2,"Half Girlfirend","Chetan Bhagat","Romance",500)
                ,new Book(3,"Veronica Decides To Die","Paul Caulho","Thriller",800)
                };
            foreach (var book in bookList)
            {
                service.AddBook(book);
            }
            List<Book> books = (List<Book>)service.GetBook();
            books[0].Should().BeEquivalentTo(service.GetBookById(1));

        }
    }
}
