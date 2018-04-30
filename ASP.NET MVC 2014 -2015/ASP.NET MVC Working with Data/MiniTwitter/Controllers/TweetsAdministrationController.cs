using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniTwitter.Models;

namespace MiniTwitter.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TweetsAdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All([DataSourceRequest] DataSourceRequest request)
        {
            var tweets = this.Data
                .Tweets
                .All()
                .Select(TweetAdministrationViewModel.FromTweet);

            return Json(tweets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, TweetAdministrationViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                try
                {
                    this.Data.Tweets.Delete(tweet.Id);
                    this.Data.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return Json(new[] { tweet }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TweetAdministrationViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                var existingTweet = this.Data.Tweets.GetById(tweet.Id);

                existingTweet.Content = tweet.Content;

                this.Data.SaveChanges();

                var hashTags = GetHashTags(tweet.Content);
                existingTweet.HashTags.Clear();

                foreach (var hashTag in hashTags)
                {
                    var resultHashTag = this.CreateOrUpdateHashTag(hashTag);
                    existingTweet.HashTags.Add(resultHashTag);
                    this.Data.HashTags.Update(resultHashTag);
                }

                this.Data.Tweets.Update(existingTweet);
                this.Data.SaveChanges();
            }

            return Json(new[] { tweet }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}