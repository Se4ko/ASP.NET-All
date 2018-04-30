using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3.InformationalApp.Data;

namespace _3.InformationalApp.Areas.Movies.Models
{
    public class MoviesMasterDetails
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }

        public int SelectedMovieId { get; set; }

        public Movie SelectedMovie { get; set; }
    }
}