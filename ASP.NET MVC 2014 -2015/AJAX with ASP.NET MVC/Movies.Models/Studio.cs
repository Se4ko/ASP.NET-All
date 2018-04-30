using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Studio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the studio is required.")]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
