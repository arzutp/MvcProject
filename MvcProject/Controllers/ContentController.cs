using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}