using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Models
{
    public class BookAdministrationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title of the book is required.")]
        [StringLength(200, ErrorMessage = "The title is too long. It should be at most 200 symbols.")]
        [AllowHtml]
        public string Title { get; set; }

        [Required(ErrorMessage = "The author of the book is required.")]
        [StringLength(150, ErrorMessage = "The author name is too long. It should be at most 150 symbols.")]
        [AllowHtml]
        public string Author { get; set; }

        [AllowHtml]
        public string ISBN { get; set; }

        [StringLength(300, ErrorMessage = "The web site is too long. It should be at most 300 symbols.")]
        [AllowHtml]
        public string Website { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [AllowHtml]
        [UIHint("Category")]
        public CategoryViewModel Category { get; set; }

        public static Expression<Func<Book, BookAdministrationViewModel>> FromBook
        {
            get
            {
                return b => new BookAdministrationViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    Website = b.Website,
                    Description = b.Description,
                    Category = new List<Category> { b.Category }.AsQueryable().Select(CategoryViewModel.FromCategory).FirstOrDefault()
                };
            }
        }
    }
}