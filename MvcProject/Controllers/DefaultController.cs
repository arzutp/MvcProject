using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        // GET: Default
        public PartialViewResult Index(int id = 0)
        {
            var contentList = cm.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}