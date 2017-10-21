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
    public class VentaController : BaseController
    {
        IDeliveryContext context;

        Venta p = new Venta();
        public VentaController()
        {
            context = new DeliveryContext();
        }

        public VentaController(IDeliveryContext c)
        {
            context = c;
        }

        // GET: Venta
        public ActionResult Index()
        {
            return View(context.GetVentas());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = context.GetVenta(id.Value);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Venta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoId,Correlativo,Serie,FechaPago,FechaRegistro")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta = context.CrearVenta(venta);
                return new JsonResult() { Data = venta };
            }

            return View(venta);
        }

        // GET: venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = context.GetVenta(id.Value);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }


        // POST: venta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dFechaHoraEntrega,dFechaHoraRegistro,nEstado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta = context.ModificarVenta(venta);
                return new JsonResult() { Data = venta };
            }
            return View(venta);
        }

        // GET: venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = context.GetVenta(id.Value);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }



        // POST: venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = context.GetVenta(id);
            context.DeleteVenta(venta);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }


        /////////DETALLE PEDIDO////////
        // GET: detalleventa/Delete/5
        public ActionResult RemoveItem(int? id, Producto producto)
        {
            if (id == null && producto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = context.GetDetalleVenta(id.Value, producto);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: Venta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Cantidad,Estado,Precio,SubTotal")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                detalleVenta = context.AgregarDetalleVenta(detalleVenta);
                return new JsonResult() { Data = detalleVenta };
            }

            return View(detalleVenta);
        }

    }
}