using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniTwitter.Models
{
    public class HomePageViewModel
    {
        public SubmitTweetViewModel NewTweet { get; set; }
        public IEnumerable<TweetViewModel> Tweets { get; set; }
    }
}