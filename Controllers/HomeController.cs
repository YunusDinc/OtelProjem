using MVCOtel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MVCOtel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return View(ctx.Sliderlar.OrderBy(x=>x.Sira).ToList());
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ActionSection()
        {
            return View();
        }

        public ActionResult OurTeam()
        {
            return View();
        }

        public ActionResult Testimonial()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Pricing() //odalar
        {
           
            return View(ctx.Odalar.OrderBy(x=>x.Fiyat).ToList());
        }
        public ActionResult Business()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RezervasyonForm(int id)
        {
            RezervasyonM r = new RezervasyonM();
            r.OdaID = id;
            r.UserID = User.Identity.GetUserId();
            ViewBag.OdaFiyat = ctx.Odalar.Find(id).Fiyat;


            return View(r);
        }

        [HttpPost]
        public ActionResult RezervasyonForm(RezervasyonM r)
        {
            var odafiyat = ctx.Odalar.Find(r.OdaID).Fiyat;
            r.Fiyat = odafiyat * r.KacKisi;
            if (ModelState.IsValid)
            {
                ctx.Rezervasyonlar.Add(r);
                ctx.SaveChanges();
            }
            return View();
        }

        ApplicationDbContext ctx = new ApplicationDbContext();
        [Authorize]
        public ActionResult Rezervasyon(int? id)
        {
            if (id == null)
                return RedirectToAction("OdaSec");

            var secilen = ctx.Odalar.Find(id);
            return View(secilen);
        }
        public string OdaSec()
        {
            return "Sayfaya id gelmediği için hangi odayı seçtiğinizi bilmiyorum. Geri dönüp tekrar deneyin.";
        }
    }
}