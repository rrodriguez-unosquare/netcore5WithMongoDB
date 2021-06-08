using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Domain.Models.Mongo;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApi.Areas.Book.Pages
{
    [ValidateAntiForgeryToken]
    public class EditModel : PageModel
    {
        private readonly IBookService _bookService;

        public EditModel(IBookService bookService)
        {
            _bookService = bookService;
            
        }

        [BindProperty(Name = "id", SupportsGet = true)]
        public string Id { get; set; }

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
            var book = _bookService.Get(this.Id);

            this.Id = book.Id;
            this.Author = book.Author;
            this.BookName = book.BookName;
            this.Category = book.Category;
            this.Price = book.Price;

        }

        
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = _bookService.Get(this.Id);

            book.BookName = this.BookName;
            book.Author = this.Author;
            book.Price = this.Price;
            book.Category = this.Category;

            _bookService.Update(this.Id, book);

            return RedirectToPage("BookStore");

        }
    }
}
