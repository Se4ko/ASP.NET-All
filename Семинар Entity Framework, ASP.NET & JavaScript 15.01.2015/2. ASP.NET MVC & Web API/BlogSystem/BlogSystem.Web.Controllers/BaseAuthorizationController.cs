namespace BlogSystem.Web.Controllers
{
    using BlogSystem.Data;
    using BlogSystem.Model;
    using System.Web.Mvc;

    [Authorize]
    public class BaseAuthorizationController : BaseController
    {
        private readonly IBlogSystemData data;

        public BaseAuthorizationController(IBlogSystemData data)
        {
            this.data = data;
        }

        protected User CurrentUser { get; private set; }

        protected override System.IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, System.AsyncCallback callback, object state)
        {
            if (CurrentUser == null && this.User.Identity.IsAuthenticated)
            {
                // this.data.Users
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
