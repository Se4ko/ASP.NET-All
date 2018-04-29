namespace BlogSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class AjaxController : Controller
    {
        public ActionResult Vote()
        {
            return this.Json(new { });
        }
    }
}
