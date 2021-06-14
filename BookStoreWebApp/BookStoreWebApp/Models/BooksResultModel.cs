using Domain.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class BooksResultModel
    {
        public BooksResultModel()
        {
            this.Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
    }
}
