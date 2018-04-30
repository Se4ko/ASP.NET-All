using MiniTwitter.Data;
using MiniTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MiniTwitter.Controllers
{
    public class BaseController : Controller
    {
        protected IUowData Data;

        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new UowData())
        {
        }

        internal List<string> GetHashTags(string tweet)
        {
            List<string> hashTags = new List<string>();

            foreach (Match match in Regex.Matches(tweet, @"#[-\w+]+"))
            {
                hashTags.Add(match.Value);
            }

            return hashTags;
        }

        internal HashTag CreateOrUpdateHashTag(string hashTag)
        {
            var existingHashTag = this.Data.HashTags.All().FirstOrDefault(h => h.Name == hashTag);
            if (existingHashTag != null)
            {
                return existingHashTag;
            }

            this.Data.HashTags.Add(new HashTag() { Name = hashTag });
            this.Data.SaveChanges();

            return this.Data.HashTags.All().First(h => h.Name == hashTag);
        }
    }
}