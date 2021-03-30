using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCrm.Models.EntityFramework;

namespace LCrm.Controllers
{
    public class HomeController : Controller
    {
        CrmEntities dbCrmEntities = new CrmEntities();
        public ActionResult Index()
        {
            var customers = dbCrmEntities.Customers.ToList();
            return View(customers);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Customers p)
        {
            dbCrmEntities.Customers.Add(p);
            dbCrmEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int Id)
        {
            var silinecek = dbCrmEntities.Customers.Find(Id);
            dbCrmEntities.Customers.Remove(silinecek);
            dbCrmEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int Id)
        {
            var update = dbCrmEntities.Customers.Find(Id);

            return View("MusteriGetir",update);
        }

        public ActionResult Guncelle(Customers p)
        {
            var customer = dbCrmEntities.Customers.Find(p.Id);
            customer.FirmaAdi = p.FirmaAdi;
            customer.YetkiliAd = p.YetkiliAd;
            customer.Tel = p.Tel;
            dbCrmEntities.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}