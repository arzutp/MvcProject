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
    public class StatisticsController : Controller
    {

        Context context = new Context();
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

        MessageManager mm = new MessageManager(new EfMessageDal());

        public ActionResult Index()
        {
            //toplam kategori sayısı
            ViewBag.total = context.Categories.Count();

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            ViewBag.numberOfTitles = context.Headings.Count(x => x.Category.CategoryName == "Yazılım");

            //Yazar adında 'a' harfi geçen yazar sayısı
            ViewBag.writer = context.Writers.Count(x=>x.WriterName.Contains("a"));

            //En fazla başlığa sahip kategori adı
            ViewBag.maxHeader = context.Headings.Max(x => x.Category.CategoryName); //4.Şartımız

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            ViewBag.difference = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);

            
            
            return View();
        }
    }
}