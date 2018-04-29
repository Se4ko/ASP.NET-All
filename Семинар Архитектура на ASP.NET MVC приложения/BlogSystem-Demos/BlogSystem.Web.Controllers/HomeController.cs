using BlogSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;
using BlogSystem.Web.Infrastructure.Constants;
using AutoMapper.QueryableExtensions;
using BlogSystem.Web.ViewModels.Posts;
using BlogSystem.Model;
using AutoMapper;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Cache;
using BlogSystem.Web.Infrastructure.Populators;

namespace BlogSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IPostsService postsData;

        public HomeController(IPostsService posts)
        {
            this.postsData = posts;
        }

        public ActionResult Index()
        {
            var postViewModel = new PostIndexViewModel
            {
                Title = "Title",
                Subtitle = "SubTitle"
            };

            return View(postViewModel);
        }

        public ActionResult Post(Post post)
        {
            return AutoMappedObjectView<Post, PostIndexViewModel>(View(post));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(Views.Index);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 60)]
        public ActionResult SameData()
        {
            // get it from db
            return PartialView("_Partial", new { });
        }

        [HttpGet]
        [PopulateContries]
        public ActionResult GetForm()
        {
            return View();
        }

        [HttpPost]
        [PopulateContries]
        public ActionResult PostForm()
        {
            // validate

            return View();
        }
    }
}