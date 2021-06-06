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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList();
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
            //cm.CategoryAddBl(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            //Business tarafında yapılmamasının sebebi işlem gerçekleşmediğinde hatayı view ile görüntüleyebilmek

            ValidationResult results = categoryValidator.Validate(category); //gelen değerlerin kontrolleri
            if (results.IsValid)
            { //sonuç geçerliyse
                cm.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");  //ekleme işlemi gerçekleştikten sonra gideceği yer
            }
            else
            {
                foreach (var item in results.Errors)  //hata mesajlarını yazdırıyoruz
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
         
    }
}