using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,  //verileri listeleme 
                                                 Value = x.CategoryId.ToString()   //Value member seçilen degerin id = value
                                                                     //display member adı = text

                                             }).ToList() ;

            List<SelectListItem> writer = (from x in wm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.WriterName,  
                                                 Value = x.WriterId.ToString()   
                                             }).ToList();
            ViewBag.vlc = category;
            ViewBag.vlw = writer;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()

                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.Update(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            
            if(headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            
            hm.Delete(headingValue);
            return RedirectToAction("Index");   
        }
    }
}