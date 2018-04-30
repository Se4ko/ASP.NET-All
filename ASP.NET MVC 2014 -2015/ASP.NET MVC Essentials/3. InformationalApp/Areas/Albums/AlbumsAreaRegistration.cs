using System.Web.Mvc;

namespace _3.InformationalApp.Areas.Albums
{
    public class AlbumsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Albums";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Albums_main",
                "Albums",
                new { controller="Albums", action = "Index" }
            );

            context.MapRoute(
                "Albums_default",
                "Albums/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}