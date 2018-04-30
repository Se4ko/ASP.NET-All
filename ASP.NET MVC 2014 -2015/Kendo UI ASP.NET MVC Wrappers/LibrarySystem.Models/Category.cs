using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the category is required.")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}