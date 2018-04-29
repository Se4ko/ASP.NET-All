namespace BlogSystem.Data.Repositories
{
    using BlogSystem.Model;

    public class UsersRepository : EfRepository<User>, IUserRepository
    {
        public UsersRepository(IBlogSystemDbContext data)
            :base(data)
        {
        }

        public User GetByUsername(string username)
        {
            return this.context.Users.Find(username);
        }
    }
}
