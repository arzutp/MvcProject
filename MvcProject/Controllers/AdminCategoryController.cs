using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidater = new CategoryValidator();
            ValidationResult results = categoryValidater.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
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

        public ActionResult DeleteCategory(int id)  //sadece index üzerinde çağırmak için kullanıcaz
        {
            var categoryValue = categoryManager.GetById(id);
            categoryManager.CategoryDelete(categoryValue);   //businessda bulunan method ile silme işlemini gerçekleştir
            return RedirectToAction("Index");  //aynı sayfaya geri gel
        }

        //güncelleme için iki işlem gerekir güncelleme sayfası ve güncelleme
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");

        }
    }
}