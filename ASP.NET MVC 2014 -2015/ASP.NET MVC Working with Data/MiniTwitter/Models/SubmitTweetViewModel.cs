using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniTwitter.Models
{
    public class SubmitTweetViewModel
    {
        [AllowHtml]
        [Required(ErrorMessage = "The tweet content is required.")]
        [StringLength(140, ErrorMessage = "The tweet must be at most 140 symbols.")]
        public string Content { get; set; }
    }
}