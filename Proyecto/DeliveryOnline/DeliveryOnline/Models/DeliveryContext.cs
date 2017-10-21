using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliveryOnline.Models
{
    public class DeliveryContext : IdentityDbContext<Persona,TipoCliente,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>, IDeliveryContext
    {
        public DeliveryContext() : base("DeliveryOnlineContext")
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }


        public Persona CrearPersona(Persona p)
        {
            //Usuarios.Add(p);
            SaveChanges();
            return p;
        }

        public Producto CrearProducto(Producto p)
        {
            Productos.Add(p);
            SaveChanges();
            return p;
        }

        public Tienda CrearTienda(Tienda t)
        {
            Tiendas.Add(t);
            SaveChanges();
            return t;
        }

        public bool DeletePersona(Persona p)
        {
            try
            {
                Users.Remove(p);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProducto(Producto p)
        {
            try
            {
                Productos.Remove(p);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTienda(Tienda t)
        {
            try
            {
                Tiendas.Remove(t);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Persona GetPersona(int id)
        {
            var guid = id.ToString();
            return Users.FirstOrDefault(g => g.Id == guid);
        }

        public List<Persona> GetPersonas()
        {
            return Users.ToList();
        }

        public Producto GetProducto(int id)
        {
            return Productos.FirstOrDefault(g => g.CodigoId == id);
        }

        public List<Producto> GetProductos()
        {
            return Productos.ToList();
        }

        public Tienda GetTienda(int id)
        {
            return Tiendas.FirstOrDefault(g => g.CodigoId == id);
        }

        public List<Tienda> GetTiendas()
        {
            return Tiendas.ToList();
        }

        public Persona ModificarPersona(Persona p)
        {
            var persona = Users.FirstOrDefault(g => g.Id == p.Id);
            persona.Apellidos = p.Apellidos;
            persona.Direccion = p.Direccion;
            persona.Email = p.Email;
            persona.PhoneNumber = p.PhoneNumber;
            persona.Nombre = p.Nombre;
            persona.PasswordHash = p.PasswordHash;
            persona.UserName = p.UserName;
            SaveChanges();
            return persona;        }

        public Producto ModificarProducto(Producto p)
        {
            var producto = Productos.FirstOrDefault(g => g.CodigoId == p.CodigoId);
            producto.Descripcion = p.Descripcion;
            producto.Imagen = p.Imagen;
            producto.TiendaId = p.TiendaId;
            SaveChanges();
            return producto;
        }

        public Tienda ModificarTienda(Tienda t)
        {
            var tienda = Tiendas.FirstOrDefault(g => g.CodigoId == t.CodigoId);
            tienda.Direccion = t.Direccion;
            tienda.Estado = t.Estado;
            tienda.FechaRegsitro =t.FechaRegsitro;
            tienda.NombreComercial = t.NombreComercial;
            tienda.RazonSocial = t.RazonSocial;
            tienda.Telefono = t.Telefono;
            SaveChanges();
            return tienda;
        }

        public static DeliveryContext Create()
        {
            return new DeliveryContext();
        }

        public List<Pedido> GetPedidos()
        {
            return Pedidos.ToList();
        }

        public List<DetallePedido> GetDetallePedidos()
        {
            return DetallePedidos.ToList();
        }

        public List<Venta> GetVentas()
        {
            return Ventas.ToList();
        }

        public List<DetalleVenta> GetDetalleVentas()
        {
            return DetalleVentas.ToList();
        }

        public Pedido CrearPedido(Pedido p)
        {
            Pedidos.Add(p);
            SaveChanges();
            return p;
        }

        public DetallePedido AgregarDetallePedido(DetallePedido dp)
        {
            DetallePedidos.Add(dp);
            SaveChanges();
            return dp;
        }

        public Venta CrearVenta(Venta v)
        {
            Ventas.Add(v);
            SaveChanges();
            return v;
        }

        public DetalleVenta AgregarDetalleVenta(DetalleVenta dv)
        {
            DetalleVentas.Add(dv);
            SaveChanges();
            return dv;
        }

        public bool DeletePedido(Pedido p)
        {
            try
            {
                Pedidos.Remove(p);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool QuitarDetallePedido(DetallePedido dp)
        {
            try
            {
                DetallePedidos.Remove(dp);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteVenta(Venta v)
        {
            try
            {
                Ventas.Remove(v);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool QuitarDetalleVenta(DetalleVenta dv)
        {
            try
            {
                DetalleVentas.Remove(dv);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Pedido ModificarPedido(Pedido p)
        {
            var pedido = Pedidos.FirstOrDefault(g => g.CodigoId == p.CodigoId);
            pedido.Estado = p.Estado;
            pedido.FechaHoraEntrega = p.FechaHoraEntrega;
            pedido.FechaHoraRegistro = p.FechaHoraRegistro;
            SaveChanges();
            return pedido;
        }

        public Venta ModificarVenta(Venta v)
        {
            var venta = Ventas.FirstOrDefault(g => g.CodigoId ==v.CodigoId);
            venta.Correlativo = v.Correlativo;
            venta.Serie = v.Serie;
            venta.FechaPago = v.FechaPago;
            venta.FechaRegistro = v.FechaRegistro;
            SaveChanges();
            return venta;
        }

        public Pedido GetPedido(int id)
        {
            return Pedidos.FirstOrDefault(g => g.CodigoId == id);
        }

        public DetallePedido GetDetallePedido(int id, Producto producto)
        {
            return DetallePedidos.FirstOrDefault(g => g.Id == id && g.m_Producto.CodigoId == producto.CodigoId );
        }

        public Venta GetVenta(int id)
        {
            return Ventas.FirstOrDefault(g => g.CodigoId == id);
        }

        public DetalleVenta GetDetalleVenta(int id, Producto producto)
        {
            return DetalleVentas.FirstOrDefault(g => g.IdVenta == id && g.m_Producto.CodigoId == producto.CodigoId);
        }
    }
}