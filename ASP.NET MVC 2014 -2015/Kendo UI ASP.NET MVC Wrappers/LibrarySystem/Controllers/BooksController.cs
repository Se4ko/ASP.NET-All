using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LibrarySystem.Context;
using LibrarySystem.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibrarySystemContext db = new LibrarySystemContext();

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var bookModel = db.Books.Select(BookDetailsViewModel.FromBook).FirstOrDefault(b => b.Id == id);
                return View(bookModel);
            }

            return HttpNotFound();
        }

        public ActionResult GetBookNamesAndAuthors(string text)
        {
            var result = db.Books.Include(b => b.Category);

            if (!string.IsNullOrWhiteSpace(text))
            {
                var searchQuery = text.ToLower();
                result = result
                    .Where(b => b.Title.ToLower().Contains(searchQuery) ||
                        b.Author.ToLower().Contains(searchQuery))
                    .OrderBy(b => b.Title)
                    .ThenBy(b => b.Author);
            }

            var data = result.Select(b => 
                new 
                {
                    Id = b.Id,
                    Value = b.Title + " by " + b.Author 
                });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}