using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        AdminManager am = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin a)
        {
            
            /*
            string userN = Sifreleme.MD5Olustur(a.AdminUserName);
            string sifre = Sifreleme.MD5Olustur(a.AdminPassword);
            var adminUser = c.Admins.FirstOrDefault(x => x.AdminUserName == userN && x.AdminPassword == sifre);
            */
            var adminUser = am.Login(a);
            if (adminUser != null)
            {
                
                FormsAuthentication.SetAuthCookie(adminUser.AdminUserName, false);
                Session["AdminUserName"] = adminUser.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }
            
        }

    }
}