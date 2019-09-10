﻿using System;
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
        public void Book_Doesnot_Get_Added_When_Invalid_BookName_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It Part-2", "William Shakespeare", "Suspense", 1000);
            service.AddBook(book);
            List<Book> books = (List<Book>)service.GetBook();
            Assert.Equal(0, books.Count);
        }

        [Fact]
        public void Book_Doesnot_Get_Added_When_Invalid_AuthorName_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It Part", "William Shakespeareq12", "Suspense", 1000);
            service.AddBook(book);
            List<Book> books = (List<Book>)service.GetBook();
            Assert.Equal(0, books.Count);
        }

        [Fact]
        public void Book_Doesnot_Get_Added_When_Invalid_Category_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It Part-2", "William Shakespeare", "Suspense431224", 1000);
            service.AddBook(book);
            List<Book> books = (List<Book>)service.GetBook();
            Assert.Equal(0, books.Count);
        }

        [Fact]
        public void Book_Doesnot_Get_Added_When_Negative_BookId_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(-1, "As You Like It Part", "William Shakespeare", "Suspense", 1000);
            service.AddBook(book);
            List<Book> books = (List<Book>)service.GetBook();
            Assert.Equal(0, books.Count);
        }

        [Fact]
        public void Book_Doesnot_Get_Added_When_Negative_Price_Is_Added()
        {
            IBookService service = new BookServiceImpl();
            Book book = new Book(1, "As You Like It Part-2", "William Shakespeare", "Suspense", -1000);
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

        [Fact]
        public void Get_Book_When_Incorrect_Id_Is_Passed()
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
            service.GetBookById(4).Should().BeNull();
        }

        [Fact]
        public void Update_book()
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
            Book tempBook = new Book(1, "Veronica decides to die", "Paul Caulho", "Suspense", 1000);
            service.UpdateBook(1, tempBook);
            tempBook.Should().BeEquivalentTo(service.GetBookById(1));
        }
    }
}
