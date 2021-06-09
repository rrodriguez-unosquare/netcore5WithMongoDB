using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApi.Areas.Book.Pages
{
    public class NewModel : PageModel
    {
        private readonly IBookService _bookService;

        public NewModel(IBookService bookService)
        {
            _bookService = bookService;

        }

        [BindProperty]
        [Required(ErrorMessage = "BookName is required")]
        public string BookName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = new Domain.Models.Mongo.Book
            {
                BookName = this.BookName,
                Author = this.Author,
                Price = this.Price,
                Category = this.Category
            };

            _bookService.Create(book);

            return RedirectToPage("BookStore");

        }
    }
}
