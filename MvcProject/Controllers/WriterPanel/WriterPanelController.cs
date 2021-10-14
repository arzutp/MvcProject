using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProject.Controllers.WriterPanel
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        // GET: WriterPanel

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = wm.GetLogin(p);
            var writerValue = wm.GetById(id);
            ViewBag.a = id;
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                wm.Update(writer);
                return RedirectToAction("AllHeading");
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


        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerValue = wm.GetLogin(p);
            var headingValues = hm.GetListByWriter(writerValue);
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string p = (string)Session["WriterMail"];
            h.WriterId = wm.GetLogin(p);
            h.HeadingStatus = true;
            hm.Add(h);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.vlc = category;
            var value = hm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {
            hm.Update(h);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page = 1)
        {
            var headings = hm.GetList().ToPagedList(page, 4); //başlangıç, kaç tane
            return View(headings);
        }
    }
}

