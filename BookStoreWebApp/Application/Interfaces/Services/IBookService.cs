using Domain.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBookService
    {
        public List<Book> Get();

        public Book Get(string id);

        public Book Create(Book book);

        public void Update(string id, Book bookIn);

        public void Remove(Book bookIn);

        public void Remove(string id);
    }
}
