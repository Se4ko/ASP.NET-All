namespace BlogSystem.Web.Controllers
{
    using BlogSystem.Model;
    using BlogSystem.Web.ViewModels.Posts;
    using System.Web.Mvc;

    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PostIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: save

                return this.RedirectToAction("Index");
            }

            return View("Index", model);
        }
    }
}