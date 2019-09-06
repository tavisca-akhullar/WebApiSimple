using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Data
{
    public class Book
    {
        public Book(int id, string name, string author, string category, double price)
        {
            Id = id;
            Name = name;
            Author = author;
            Category = category;
            Price = price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string  Category { get; set; }
        public double Price { get; set; }
    }
 }

