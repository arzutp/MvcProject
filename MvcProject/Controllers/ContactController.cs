using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        Context context = new Context();
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EFContactDal());
        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            ViewBag.inbox = context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com" && x.Drafts == false && x.Trash == false);
            ViewBag.sendbox = context.Messages.Count(x => x.SenderMail == "admin@gmail.com" && x.Drafts == false && x.Trash == false);
            ViewBag.drafts = context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com" && x.Drafts == true && x.Trash == false);
            ViewBag.trash = context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com" && x.Trash == true && x.Drafts == false);

            return PartialView();
        }
    }
}