using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("Movies")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Studio> Studios { get; set; }
    }
}
