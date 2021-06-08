using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApi.Areas.Book.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public Domain.Models.Mongo.Book Book { get; set; }

        public DetailsModel(IBookService bookService)
        {
            _bookService = bookService;

        }

        [BindProperty(Name = "id", SupportsGet = true)]
        public string Id { get; set; }

        public void OnGet()
        {
            this.Book = _bookService.Get(this.Id);

        }
    }
}
