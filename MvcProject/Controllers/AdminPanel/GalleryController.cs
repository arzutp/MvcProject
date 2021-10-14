using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers.AdminPanel
{
    public class GalleryController : Controller
    {
        ImageManager im = new ImageManager(new EfImageDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}