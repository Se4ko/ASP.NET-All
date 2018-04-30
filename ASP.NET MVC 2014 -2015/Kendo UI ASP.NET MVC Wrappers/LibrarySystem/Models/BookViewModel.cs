using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    CategoryName = b.Category.Name
                };
            }
        }
    }
}