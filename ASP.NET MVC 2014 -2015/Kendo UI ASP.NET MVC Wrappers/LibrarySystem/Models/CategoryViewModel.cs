using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Name { get; set; }

        public ICollection<BookViewModel> Books { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Books = c.Books.AsQueryable().Select(BookViewModel.FromBook).ToList()
                };
            }
        }
    }
}