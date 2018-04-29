namespace BlogSystem.Web.Infrastructure.ActionResults.Contracts
{
    public interface IPostedDataActionHandler<T>
    {
        void Handle(T action);
    }
}
