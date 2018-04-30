using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Models
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public static Expression<Func<Book, BookDetailsViewModel>> FromBook
        {
            get
            {
                return b => new BookDetailsViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    Website = b.Website,
                    Description = b.Description
                };
            }
        }
    }
}