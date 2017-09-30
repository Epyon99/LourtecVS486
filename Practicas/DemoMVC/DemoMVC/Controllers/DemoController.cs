using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            Photo p = new Photo();
            DevolverDatos();
            p.PhotoID = new Random().Next(1, 100000);
            return View(p);
        }

        [HttpPost]
        public ActionResult Crear(Photo p)
        {
            PhotoContext c = new PhotoContext();
            c.Photos.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        private int DevolverDatos()
        {
            return 1;
        }
    }
}