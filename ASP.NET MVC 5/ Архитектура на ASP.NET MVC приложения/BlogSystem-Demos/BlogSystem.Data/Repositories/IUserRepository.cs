using BlogSystem.Model;
namespace BlogSystem.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
    }
}
