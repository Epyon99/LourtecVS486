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
    public class PersonaController : BaseController
    {
        IDeliveryContext context;
        public PersonaController()
        {
            context = new DeliveryContext();
        }

        public PersonaController(IDeliveryContext c)
        {
            context = c;
        }

        // GET: Persona
        public ActionResult Index()
        {
            return View(context.GetPersonas());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = context.GetPersona(id.Value);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoId,PersonaField,Apellidos,Direccion,Email,FonoCelular,Nombre,Password")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona = context.CrearPersona(persona);
                return new JsonResult() { Data = persona } ;
            }

            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = context.GetPersona(id.Value);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoId,PersonaField,Apellidos,Direccion,Email,FonoCelular,Nombre,Password")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona = context.ModificarPersona(persona);
                //db.Entry(persona).State = EntityState.Modified;
                //db.SaveChanges();
                return new JsonResult() { Data = persona } ;
            }
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = context.GetPersona(id.Value);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = context.GetPersona(id);
            context.DeletePersona(persona);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
