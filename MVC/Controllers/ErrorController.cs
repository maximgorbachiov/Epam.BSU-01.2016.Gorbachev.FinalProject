using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}