using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MiniTwitter.Models;

namespace MiniTwitter.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<HashTag> HashTags { get; set; }
    }
}
