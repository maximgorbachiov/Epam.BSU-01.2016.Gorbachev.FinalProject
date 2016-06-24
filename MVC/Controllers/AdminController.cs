using System.Linq;
using System.Web.Mvc;
using MVC.Models.Shared;
using MVC.Infrastructure.Mappers;
using BLL.Interfaces;
using BLL.Entities;

namespace MVC.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITestService service;

        public AdminController(ITestService service)
        {
            this.service = service;
        }

        // GET: Admin
        public ActionResult Index()
        {
            //var temp = service.GetAllTestEntities().Select(test => test.ToMvcTest());
            //return View(temp);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestViewModel testViewModel)
        {
            service.CreateTest(testViewModel.ToBllTest());
            return RedirectToAction("Index");
        }

        //GET-запрос к методу Delete несет потенциальную уязвимость!
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            TestEntity test = service.GetTestEntity(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test.ToMvcTest());
        }

        //Post/Redirect/Get (PRG) — модель поведения веб-приложений, используемая
        //разработчиками для защиты от повторной отправки данных веб-форм
        //(Double Submit Problem)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TestEntity test)
        {
            service.DeleteTest(test);
            return RedirectToAction("Index");
        }
    }
}