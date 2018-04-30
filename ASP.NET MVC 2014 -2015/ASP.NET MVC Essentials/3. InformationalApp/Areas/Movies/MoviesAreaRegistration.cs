using System.Web.Mvc;

namespace _3.InformationalApp.Areas.Movies
{
    public class MoviesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Movies";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Movies_main",
                "Movies",
                new { controller="Movies", action = "Index" }
            );
            context.MapRoute(
                "Movies_default",
                "Movies/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}