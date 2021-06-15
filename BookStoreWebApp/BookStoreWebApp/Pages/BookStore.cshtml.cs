using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.Services;
using BookStoreWebApp.Models;
using BookStoreWebApp.Services;
using Domain.Dtos;
using Domain.Models.Mongo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BookStoreApi.Pages
{
    [IgnoreAntiforgeryToken]
    public class BookStoreModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly IRazorPartialToStringRenderer _razorRenderer;

        public BooksResultModel BookResult { get; set; }

        public BookStoreModel(IBookService bookService, IRazorPartialToStringRenderer razorRenderer)
        {
            _bookService = bookService;
            _razorRenderer = razorRenderer;
            this.BookResult = new BooksResultModel();
        }

        public void OnGet()
        {
            this.BookResult.Books.AddRange(_bookService.Get());

        }

        public async Task<IActionResult> OnPostSearchBooks(SearchBooksDto dto)
        {
            
           

            var response = await _bookService.SearchAsync(dto);
            string viewName = "_BooksResult";

            try
            {
                response.Html = await _razorRenderer.RenderPartialToStringAsync(viewName, new BooksResultModel { Books = response.GetBooks() });

            }
            catch(Exception ex)
            {
                return new JsonResult(ex);
            }

            

            return new JsonResult(response);
        }
    }
}
