using Domain.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class SearchBooksDto
    {
        public SearchBooksDto()
        {
            this.OrderBy = ESearchBookOrderBy.BookName;
            this.OrderType = EOrderType.ASC;
        }

        public string CriteriaText { get; set; }

        public int PageNumber { get; set; }


        public int PageSize { get; set; }

        public ESearchBookOrderBy OrderBy { get; set; }

        public EOrderType OrderType { get; set; }

    }


    public enum ESearchBookOrderBy
    {
        BookName=0,
        Category=1,
        Author=2
    }


    public class SearchBooksResponseDto
    {
        private List<Book> _books;

        public SearchBooksResponseDto(List<Book> books)
        {
            this._books = books;
        }

        public long TotalItems { get; set; }

        public long ItemsInPage { get; set; }

        public int CurrentPage { get; set; }

        public object Data { get; set; }
        public string Html { get; set; }

        public List<Book> GetBooks()
        {
            return this._books;
        }
    }
}
