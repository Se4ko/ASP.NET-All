using _3.InformationalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.InformationalApp.Areas.Albums.Controllers
{
    public class AlbumsController : Controller
    {
        public ActionResult Index()
        {
            List<Album> albums = Data.Data.GetAllAlbums();

            return View(albums);
        }
	}
}