using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            var values = categoryManager.GetList().ToPagedList(page, 3);
            return View(values);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.TAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult CategoryDelete(int id)
        {
            var value = categoryManager.TGetById(id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
