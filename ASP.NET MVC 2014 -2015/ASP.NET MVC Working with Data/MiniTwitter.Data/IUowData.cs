using System;
using MiniTwitter.Models;

namespace MiniTwitter.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<HashTag> HashTags { get; }

        int SaveChanges();
    }
}
