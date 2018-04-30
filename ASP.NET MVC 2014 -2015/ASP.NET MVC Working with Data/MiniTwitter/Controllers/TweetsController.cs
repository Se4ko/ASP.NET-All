using MiniTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace MiniTwitter.Controllers
{
    public class TweetsController : BaseController
    {
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubmitTweetViewModel tweet)
        {
            TweetViewModel result = new TweetViewModel();
            if (tweet != null && ModelState.IsValid)
            {
                var user = this.Data.Users.GetById(User.Identity.GetUserId());
                var newTweet = new Tweet()
                {
                    Content = tweet.Content,
                    User = user,
                    CreationDate = DateTime.Now
                };

                this.Data.Tweets.Add(newTweet);
                this.Data.SaveChanges();

                var hashTags = GetHashTags(tweet.Content);
                foreach (var hashTag in hashTags)
                {
                    var resultHashTag = this.CreateOrUpdateHashTag(hashTag);
                    newTweet.HashTags.Add(resultHashTag);
                    this.Data.HashTags.Update(resultHashTag);
                }

                this.Data.Tweets.Update(newTweet);
                this.Data.SaveChanges();

                result.Content = newTweet.Content;
                result.CreationDate = newTweet.CreationDate;
                result.UserId = newTweet.UserId;
                result.Username = newTweet.User.UserName;
            }

            return PartialView("_Tweet", result);
        }

        public ActionResult HashTag(string hashTag)
        {
            var tweets = new List<TweetViewModel>();
            if (this.HttpContext.Cache[hashTag] != null)
            {
                tweets = this.HttpContext.Cache[hashTag] as List<TweetViewModel>;
            }
            else
            {
                var existingHashTag = this.Data.HashTags.All().FirstOrDefault(h => h.Name == hashTag);
                if (existingHashTag != null)
                {
                    tweets = this.Data.Tweets
                        .All()
                        .Where(t => t.Content.Contains(hashTag))
                        .Select(TweetViewModel.FromTweet)
                        .ToList();
                    this.HttpContext.Cache.Add(
                        hashTag,
                        tweets,
                        null,
                        DateTime.Now.AddMinutes(1),
                        TimeSpan.Zero,
                        System.Web.Caching.CacheItemPriority.Default,
                        null);
                }
            }

            return View(this.HttpContext.Cache[hashTag] as List<TweetViewModel>);
        }

        [ActionName("User")]
        public ActionResult ByUser(string id)
        {
            var tweets = this.Data.Users.GetById(id)
                .Tweets
                .AsQueryable()
                .Select(TweetViewModel.FromTweet);

            return View(tweets);
        }
    }
}