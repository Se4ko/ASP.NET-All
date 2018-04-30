using _3.InformationalApp.Areas.Movies.Models;
using _3.InformationalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.InformationalApp.Areas.Movies.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index(int? id = null)
        {
            var model = new MoviesMasterDetails();
            model.Movies = Data.Data.GetAllMovies().AsQueryable().Select(MovieViewModel.FromMovie);

            if (id != null)
            {
                model.SelectedMovie = Data.Data.GetAllMovies().Find(x => x.Id == id);
            }
            
            return View(model);
        }
    }
}