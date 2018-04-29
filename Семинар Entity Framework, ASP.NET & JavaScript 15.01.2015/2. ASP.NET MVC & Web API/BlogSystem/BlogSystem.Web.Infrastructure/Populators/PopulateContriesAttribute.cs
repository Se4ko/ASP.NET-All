namespace BlogSystem.Web.Infrastructure.Populators
{
    using BlogSystem.Web.Infrastructure.Cache;
    using Ninject;
    using System.Web.Mvc;

    public class PopulateContriesAttribute : ActionFilterAttribute
    {
        [Inject]
        public ICacheService Cache { private get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Countries = Cache.Countries;
            base.OnResultExecuting(filterContext);
        }
    }
}
