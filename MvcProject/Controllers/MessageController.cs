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

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        Context c = new Context();
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
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
                    m.SenderMail = "admin@gmail.com";
                    mm.Add(m);
                    return RedirectToAction("Drafts");
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
                    m.SenderMail = "admin@gmail.com";
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

        public ActionResult GetInboxDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }

        //Taslaklar ve çöp kutusu listeleme
        public ActionResult Trash()
        {
            var messageList = mm.GetListTrash();
            return View(messageList);
        }

        public ActionResult Drafts()
        {
            var messageList = mm.GetListDrafts();
            return View(messageList);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }

        public ActionResult MessageRead(int id)
        {
            var value = mm.GetById(id);

            if (value.isRead == true)
            {
                value.isRead = false;
                
            }
            else
            {
                value.isRead = true;
                
            }

            mm.Update(value);
            return RedirectToAction("Inbox");

        }
    }
}