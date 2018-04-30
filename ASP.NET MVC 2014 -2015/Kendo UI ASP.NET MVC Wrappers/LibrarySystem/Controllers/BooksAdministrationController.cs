using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Context;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class BooksAdministrationController : Controller
    {
        private LibrarySystemContext db = new LibrarySystemContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All([DataSourceRequest] DataSourceRequest request)
        {
            var result = db.Books.Include(b => b.Category).Select(BookAdministrationViewModel.FromBook);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BookAdministrationViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var category = db.Categories.Find(book.Category.Id);
                if (category == null || book.Category.Id == 0)
                {
                    category = db.Categories.First();
                }

                var newBook = new Book()
                    {
                        Title = book.Title,
                        Author = book.Author,
                        ISBN = book.ISBN,
                        Website = book.Website,
                        Description = book.Description,
                        Category = category
                    };

                db.Books.Add(newBook);
                db.SaveChanges();

                book.Category.Name = newBook.Category.Name;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, BookAdministrationViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var bookDb = db.Books.Find(book.Id);
                var category = db.Categories.Find(book.Category.Id);

                bookDb.Title = book.Title;
                bookDb.Author = book.Author;
                bookDb.ISBN = book.ISBN;
                bookDb.Website = book.Website;
                bookDb.Description = book.Description;
                bookDb.Category = category;

                db.SaveChanges();
                book.Category.Name = bookDb.Category.Name;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, BookAdministrationViewModel book)
        {
            if (book != null)
            {
                var bookDb = db.Books.Find(book.Id);
                db.Books.Remove(bookDb);
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}