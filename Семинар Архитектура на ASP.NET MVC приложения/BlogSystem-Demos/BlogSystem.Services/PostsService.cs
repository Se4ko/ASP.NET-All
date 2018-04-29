namespace BlogSystem.Services
{
    using System.Linq;

    using BlogSystem.Data;
    using BlogSystem.Model;
    using BlogSystem.Services.Contracts;

    public class PostsService : IPostsService
    {
        private IRepository<Post> data;

        public PostsService(IRepository<Post> data)
        {
            this.data = data;
        }

        public IQueryable<Post> GetAllByUser(string user)
        {
            return this.data.All()
                .Where(p => p.User.Contacts.Email == user)
                .OrderBy(p => p.PostedOn);
        }
    }
}
