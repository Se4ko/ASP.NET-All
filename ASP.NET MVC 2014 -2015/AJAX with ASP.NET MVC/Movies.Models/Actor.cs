using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Movies.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the actor is required.")]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The age of the actor is required.")]
        [Range(0, 150, ErrorMessage = "The age of the actor must be between 0 and 150.")]
        public int Age { get; set; }
    }
}
