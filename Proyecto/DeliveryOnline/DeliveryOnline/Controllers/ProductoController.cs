using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryOnline.Models;
using System.Net.Http;

namespace DeliveryOnline.Controllers
{
    public class ProductoController : BaseController
    {
        private DeliveryContext db = new DeliveryContext();

        // GET: Productoes
        public async ActionResult Index()
        {
            // Controller de Productos
            // Y quieren llamar al Controller de Tiendas.
            var productos = db.Productos.Include(p => p.Tienda);
            // Html.ActionLink -- No exite
            //RedirectToAction("Index", "Tienda"); -- Pero pierden los datos de Producto Tiendas
            //TiendaController c = new TiendaController();
            //var action = c.Index();
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://localhost:12345/Tienda");
            using (HttpContent content = result.Content)
            {
                string r = await content.ReadAsStringAsync();
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(r);
            }
            return View(productos.ToList());
        }

        public ActionResult ProductoByTienda(int TiendaId)
        {
            var productos = db.Productos.Where(g => g.TiendaId == TiendaId).Include("Tienda");
            return View("Index",productos.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "CodigoId,TiendaId,descripcion,Imagen")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.TiendaId == 0)
                {
                    producto.Tienda = new Tienda()
                    {
                        NombreComercial = "Tienda Nueva"
                    };
                }
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion", producto.TiendaId);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion", producto.TiendaId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoId,TiendaId,descripcion,Imagen")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion", producto.TiendaId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
