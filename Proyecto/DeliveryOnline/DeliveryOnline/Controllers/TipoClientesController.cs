using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryOnline.Models;

namespace DeliveryOnline.Controllers
{
    public class TipoClientesController : BaseController
    {

        // GET: TipoClientes
        public ActionResult Index()
        {
            return View(DbContext.Roles.ToList());
        }

        // GET: TipoClientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCliente tipoCliente = DbContext.Roles.Find(id);
            if (tipoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoCliente);
        }

        // GET: TipoClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TipoCliente tipoCliente)
        {
            if (ModelState.IsValid)
            {
                DbContext.Roles.Add(tipoCliente);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCliente);
        }

        // GET: TipoClientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCliente tipoCliente = DbContext.Roles.Find(id);
            if (tipoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoCliente);
        }

        // POST: TipoClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TipoCliente tipoCliente)
        {
            if (ModelState.IsValid)
            {
                DbContext.Entry(tipoCliente).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCliente);
        }

        // GET: TipoClientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCliente tipoCliente = DbContext.Roles.Find(id);
            if (tipoCliente == null)
            {
                return HttpNotFound();
            }
            return View(tipoCliente);
        }

        // POST: TipoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TipoCliente tipoCliente = DbContext.Roles.Find(id);
            DbContext.Roles.Remove(tipoCliente);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
