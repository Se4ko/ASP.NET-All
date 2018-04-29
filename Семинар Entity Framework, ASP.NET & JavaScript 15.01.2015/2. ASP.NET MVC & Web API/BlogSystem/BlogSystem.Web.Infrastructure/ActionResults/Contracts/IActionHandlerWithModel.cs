namespace BlogSystem.Web.Infrastructure.ActionResults.Contracts
{
    public interface IActionHandlerWithModel<T>
    {
        T Handle();
    }
}
