using System.Linq;
using System.Web.Mvc;
using MVC.Models.Shared;
using MVC.Infrastructure.Mappers;
using BLL.Interfaces;
using BLL.Entities;

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var temp = service.GetAllCategoryEntities().Select(category => category.ToMvcCategory());
            return View(temp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            service.CreateCategory(categoryViewModel.ToBllCategory());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            CategoryViewModel category = service.GetCategoryEntity(id).ToMvcCategory();

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            string oldName = service.GetCategoryEntity(categoryViewModel.Id).CategoryName;

            if (service.IsCategoryWithNameExist(categoryViewModel.CategoryName) && (oldName != categoryViewModel.CategoryName))
            {
                ModelState.AddModelError("", "Category with the same name is exist.");
            }

            if (ModelState.IsValid)
            {
                service.UpdateCategory(categoryViewModel.ToBllCategory());

                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            CategoryEntity category = service.GetCategoryEntity(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category.ToMvcCategory());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(CategoryEntity category)
        {
            service.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}