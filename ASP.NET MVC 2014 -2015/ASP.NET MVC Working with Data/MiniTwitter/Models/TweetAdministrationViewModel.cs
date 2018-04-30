using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MiniTwitter.Models
{
    public class TweetAdministrationViewModel
    {
        public int Id { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "The tweet content is required.")]
        [StringLength(140, ErrorMessage = "The tweet must be at most 140 symbols.")]
        public string Content { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<HashTagViewModel> HashTags { get; set; }

        public static Expression<Func<Tweet, TweetAdministrationViewModel>> FromTweet
        {
            get
            {
                return t => new TweetAdministrationViewModel()
                    {
                        Id = t.Id,
                        Content = t.Content,
                        CreationDate = t.CreationDate,
                        UserId = t.UserId,
                        Username = t.User.UserName,
                        HashTags = t.HashTags
                            .AsQueryable()
                            .Select(HashTagViewModel.FromHashTag)
                            .ToList()
                    };
            }
        }
    }
}