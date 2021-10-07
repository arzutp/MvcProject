using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers.WriterPanel
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        Context c = new Context();
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            var message = mm.GetListInbox();
            return View(message);
        }

        public ActionResult InboxDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }

        public ActionResult Sendbox()
        {
            var message = mm.GetListSendbox();
            return View(message);
        }

        public ActionResult SendboxDetails(int id)
        {
            var message = mm.GetById(id);
            return View(message);
        }

        public ActionResult Draft()
        {
            var message = mm.GetListDrafts();
            return View(message);
        }

        public ActionResult DraftDetails(int id)
        {
            var message = mm.GetById(id);
            return View(message);
        }

        public ActionResult Trash()
        {
            var message = mm.GetListDrafts();
            return View(message);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult NewMessage(Message m, string button)
        {
            ValidationResult result = mv.Validate(m);

            if (button == "draft")
            {

                result = mv.Validate(m);
                if (result.IsValid)
                {
                    m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    m.Drafts = true;
                    m.SenderMail = "arzu@gmail.com";
                    mm.Add(m);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

            }

            if (button == "save")
            {
                result = mv.Validate(m);
                if (result.IsValid)
                {
                    m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    m.Drafts = false;
                    m.SenderMail = "arzu@gmail.com";
                    mm.Add(m);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }


            return View();

        }

        public PartialViewResult MessagePartial()
        {
            ViewBag.inbox = c.Messages.Count(x => x.ReceiverMail == "arzu@gmail.com" && x.Drafts == false && x.Trash == false);
            ViewBag.sendbox = c.Messages.Count(x=>x.SenderMail== "arzu@gmail.com" && x.Drafts == false && x.Trash == false);
            ViewBag.trash = c.Messages.Count(x => x.ReceiverMail == "arzu@gmail.com" && x.Drafts == false && x.Trash == true);
            ViewBag.draft = c.Messages.Count(x => x.SenderMail == "arzu@gmail.com" && x.Drafts == true && x.Trash == false);
            return PartialView();
        }
    }
}