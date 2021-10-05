using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class TalentController : Controller
    {
        // GET: Chart
        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skills = sm.GetList();
            return View(skills);
        }
    }
}