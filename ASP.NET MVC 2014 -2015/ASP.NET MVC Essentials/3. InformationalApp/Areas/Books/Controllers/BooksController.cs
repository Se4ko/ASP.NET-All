using _3.InformationalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.InformationalApp.Areas.Books.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            List<Book> books = Data.Data.GetAllBooks();
            
            return View(books);
        }
	}
}