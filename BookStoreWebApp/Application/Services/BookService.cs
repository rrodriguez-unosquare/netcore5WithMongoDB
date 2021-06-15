using Application.Interfaces.Services;
using Domain.Dtos;
using Domain.Interfaces.Models;
using Domain.Models.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService: IBookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<SearchBooksResponseDto> SearchAsync(SearchBooksDto dto)
        {
            var query = _books.Find(x => x.Author.Contains(dto.CriteriaText) || x.BookName.Contains(dto.CriteriaText) || x.Category.Contains(dto.CriteriaText));
            var totalTask = query.CountDocumentsAsync();
            var itemsTask = query.Skip(dto.PageNumber -1).Limit(dto.PageSize).ToListAsync();
            await Task.WhenAll(totalTask, itemsTask);
            var response = new SearchBooksResponseDto(itemsTask.Result)
            {
                TotalItems = totalTask.Result,
                ItemsInPage = itemsTask.Result.Count

            };

            return response;
        }


        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
