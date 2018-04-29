namespace BlogSystem.Services.Contracts
{
    using BlogSystem.Model;
    using System.Linq;

    public interface IPostsService : IService
    {
        IQueryable<Post> GetAllByUser(string user);
    }
}
