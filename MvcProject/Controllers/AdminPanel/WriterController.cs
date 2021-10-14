using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers.AdminPanel
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator validationRules = new WriterValidator();

        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                wm.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                wm.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}