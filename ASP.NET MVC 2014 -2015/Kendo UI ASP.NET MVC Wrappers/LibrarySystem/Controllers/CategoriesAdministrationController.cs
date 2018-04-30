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
    [Authorize]
    public class CategoriesAdministrationController : Controller
    {
        private readonly LibrarySystemContext db = new LibrarySystemContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            var categories = db.Categories.Select(CategoryViewModel.FromCategory);
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var categories = db.Categories.Select(CategoryViewModel.FromCategory);
            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(category.Name))
                {
                    ModelState.AddModelError("CategoryName", "The category name is required.");
                }

                var newCategory = new Category() { Name = category.Name };
                db.Categories.Add(newCategory);
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(category.Name))
                {
                    ModelState.AddModelError("CategoryName", "The category name is required.");
                }

                var categoryDb = db.Categories.Find(category.Id);
                categoryDb.Name = category.Name;
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null)
            {
                var categoryDb = db.Categories.Find(category.Id);
                db.Books.RemoveRange(categoryDb.Books);
                db.Categories.Remove(categoryDb);
                db.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}