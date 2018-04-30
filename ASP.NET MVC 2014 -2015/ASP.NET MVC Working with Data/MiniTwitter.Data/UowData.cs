namespace MiniTwitter.Data
{
    using MiniTwitter.Models;
    using System;
    using System.Collections.Generic;

    public class UowData : IUowData
    {
        private readonly ApplicationDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData()
            : this(new ApplicationDbContext())
        {
        }

        public UowData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
        }

        public IRepository<HashTag> HashTags
        {
            get
            {
                return this.GetRepository<HashTag>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
