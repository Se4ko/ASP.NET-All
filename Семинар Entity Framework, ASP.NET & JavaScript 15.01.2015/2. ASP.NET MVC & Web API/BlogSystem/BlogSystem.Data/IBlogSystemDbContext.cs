namespace BlogSystem.Data
{
    using BlogSystem.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IBlogSystemDbContext
    {
        IDbSet<Post> Posts { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
