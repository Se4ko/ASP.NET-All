using System.Web.Mvc;

namespace _3.InformationalApp.Areas.Books
{
    public class BooksAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Books";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Books_main",
                "Books",
                new { controller="Books", action = "Index" }
            );

            context.MapRoute(
                "Books_default",
                "Books/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}