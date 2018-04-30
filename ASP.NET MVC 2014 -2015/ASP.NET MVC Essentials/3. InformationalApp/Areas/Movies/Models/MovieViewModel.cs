using _3.InformationalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace _3.InformationalApp.Areas.Movies.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title
                };
            }
        }
    }
}