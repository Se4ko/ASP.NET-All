using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title of the book is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The author of the book is required.")]
        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Website { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The category of the book is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The category of the book is required.")]
        public virtual Category Category { get; set; }
    }
}