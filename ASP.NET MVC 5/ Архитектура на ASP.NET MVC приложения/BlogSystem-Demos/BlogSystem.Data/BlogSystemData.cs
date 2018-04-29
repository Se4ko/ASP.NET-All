namespace BlogSystem.Data
{
    using BlogSystem.Data.Repositories;
    using BlogSystem.Model;
    using System;
    using System.Collections.Generic;

    public class BlogSystemData : IBlogSystemData
    {
        private IBlogSystemDbContext context;

        private IDictionary<Type, object> dict;

        public BlogSystemData(IBlogSystemDbContext context)
        {
            this.context = context;
        }

        public IRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IUserRepository Users
        {
            get
            {
                return (IUserRepository)this.GetRepository<User>();
            }
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var type = typeof(T);

            if (!dict.ContainsKey(type))
            {
                var repositoryType = typeof(EfRepository<T>);

                if (type.IsAssignableFrom(typeof(User)))
                {
                    repositoryType = typeof(IUserRepository);
                }
                
                var instance = Activator.CreateInstance(repositoryType, this.context);

                dict.Add(type, instance);
            }

            return (IRepository<T>)dict[type];
        }
    }
}
