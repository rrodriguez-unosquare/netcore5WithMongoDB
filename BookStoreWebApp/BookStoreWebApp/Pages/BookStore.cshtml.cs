using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services;
using Application.Services;
using BookStoreWebApp.Models;
using BookStoreWebApp.Services;
using Domain.Dtos;
using Domain.Models.Mongo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace BookStoreApi.Pages
{
    [IgnoreAntiforgeryToken]
    public class BookStoreModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly IRazorPartialToStringRenderer _razorRenderer;

        public BooksResultModel BookResult { get; set; }

        public BookStoreModel(IBookService bookService, IRazorPartialToStringRenderer razorRenderer, IWebHostEnvironment env)
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
            
           

            

            try
            {

                using (var client = new HttpClient())
                {
                    var jsonInString = JsonConvert.SerializeObject(dto);
                    var uri = Environment.GetEnvironmentVariable("BookStoreApiBaseAddress") + "api/books/search";

                    var httpResponse = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

                    var jsonResponse= await httpResponse.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<SearchBooksResponseDto>(jsonResponse);

                    string viewName = "_BooksResult";
                    response.Html = await _razorRenderer.RenderPartialToStringAsync(viewName, new BooksResultModel { Books = response.Books });
                    return new JsonResult(response);
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(ex);
            }

            

            
        }
    }
}
