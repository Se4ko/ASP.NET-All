namespace BlogSystem.Web.Infrastructure.Cache
{
    using BlogSystem.Data;
    using System.Collections.Generic;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IBlogSystemData data;

        public MemoryCacheService(IBlogSystemData data)
        {
            this.data = data;
        }

        public IList<string> Countries
        {
            get
            {
                return this.Get<IList<string>>("Countries",
                    () =>
                    {
                        return null;
                    });
            }
        }
    }
}
