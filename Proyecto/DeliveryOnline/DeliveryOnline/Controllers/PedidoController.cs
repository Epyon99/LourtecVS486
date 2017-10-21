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
    public class PedidoController : BaseController
    {
        IDeliveryContext context;

        Pedido p = new Pedido();
        public PedidoController()
        {
            context = new DeliveryContext();
        }

        public PedidoController(IDeliveryContext c)
        {
            context = c;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            return View(context.GetPedidos());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.GetPedido(id.Value);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dFechaHoraEntrega,dFechaHoraRegistro,nEstado")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido = context.CrearPedido(pedido);
                return new JsonResult() { Data = pedido };
            }

            return View(pedido);
        }

        // GET: pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.GetPedido(id.Value);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }


        // POST: pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dFechaHoraEntrega,dFechaHoraRegistro,nEstado")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido = context.ModificarPedido(pedido);
                return new JsonResult() { Data = pedido };
            }
            return View(pedido);
        }

        // GET: pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = context.GetPedido(id.Value);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }



        // POST: pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = context.GetPedido(id);
            context.DeletePedido(pedido);
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
        // GET: detallepedido/Delete/5
        public ActionResult RemoveItem(int? id, Producto producto)
        {
            if (id == null && producto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = context.GetDetallePedido(id.Value, producto);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Cantidad,Estado,Precio,SubTotal")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                detallePedido = context.AgregarDetallePedido(detallePedido);
                return new JsonResult() { Data = detallePedido };
            }

            return View(detallePedido);
        }

    }
}