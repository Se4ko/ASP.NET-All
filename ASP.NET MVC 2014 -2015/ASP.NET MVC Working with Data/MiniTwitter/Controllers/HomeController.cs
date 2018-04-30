using MiniTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniTwitter.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.CreationDate)
                .Select(TweetViewModel.FromTweet)
                .ToList();
            var viewModel = new HomePageViewModel()
            {
                Tweets = tweets,
                NewTweet = new SubmitTweetViewModel()
            };

            return View(viewModel);
        }
    }
}