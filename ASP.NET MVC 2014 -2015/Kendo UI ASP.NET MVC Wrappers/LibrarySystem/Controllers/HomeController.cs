using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.Context;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibrarySystemContext db = new LibrarySystemContext();

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
    }
}