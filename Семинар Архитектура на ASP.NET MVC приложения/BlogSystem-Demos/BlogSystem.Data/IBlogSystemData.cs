namespace BlogSystem.Data
{
    using BlogSystem.Data.Repositories;
    using BlogSystem.Model;

    public interface IBlogSystemData
    {
        IRepository<Post> Posts { get; }

        IUserRepository Users { get; }
    }
}
