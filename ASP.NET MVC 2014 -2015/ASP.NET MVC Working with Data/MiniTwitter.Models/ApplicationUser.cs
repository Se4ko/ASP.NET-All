using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace MiniTwitter.Models
{
    public class ApplicationUser : User
    {
        public string Email { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
