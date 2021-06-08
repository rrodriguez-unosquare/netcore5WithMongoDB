using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Models.Mongo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApi.Pages
{
    public class BookStoreModel : PageModel
    {
        private readonly IBookService _bookService;

        public List<Book> Books { get; set; }

        public BookStoreModel(IBookService bookService)
        {
            _bookService = bookService;
            this.Books = new List<Book>();
        }

        public void OnGet()
        {
            this.Books.AddRange(_bookService.Get());

        }
    }
}
