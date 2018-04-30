using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MiniTwitter.Models
{
    public class TweetViewModel
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime CreationDate { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return t => new TweetViewModel()
                    {
                        Content = t.Content,
                        CreationDate = t.CreationDate,
                        UserId = t.UserId,
                        Username = t.User.UserName
                    };
            }
        }
    }
}