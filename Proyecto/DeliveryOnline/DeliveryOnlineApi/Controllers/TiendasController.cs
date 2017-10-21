using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DeliveryOnline.Models;

namespace DeliveryOnlineApi.Controllers
{
    public class TiendasController : ApiController
    {
        private DeliveryContext db = new DeliveryContext();

        // GET: api/Tiendas
        public IQueryable<Tienda> GetTiendas()
        {
            return db.Tiendas;
        }

        // GET: api/Tiendas/5
        [ResponseType(typeof(Tienda))]
        public IHttpActionResult GetTienda(int id)
        {
            Tienda tienda = db.Tiendas.Find(id);
            if (tienda == null)
            {
                return NotFound();
            }

            return Ok(tienda);
        }

        // PUT: api/Tiendas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTienda(int id, Tienda tienda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tienda.CodigoId)
            {
                return BadRequest();
            }

            db.Entry(tienda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tiendas
        [ResponseType(typeof(Tienda))]
        public IHttpActionResult PostTienda(Tienda tienda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tiendas.Add(tienda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tienda.CodigoId }, tienda);
        }

        // DELETE: api/Tiendas/5
        [ResponseType(typeof(Tienda))]
        public IHttpActionResult DeleteTienda(int id)
        {
            Tienda tienda = db.Tiendas.Find(id);
            if (tienda == null)
            {
                return NotFound();
            }

            db.Tiendas.Remove(tienda);
            db.SaveChanges();

            return Ok(tienda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TiendaExists(int id)
        {
            return db.Tiendas.Count(e => e.CodigoId == id) > 0;
        }
    }
}