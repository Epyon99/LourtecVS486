using DeliveryOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOnline.Tests.Doubles
{
    class FakeMemoryContext : IDeliveryContext
    {
        List<Persona> Usuarios = new List<Persona>();
        List<Tienda> Tiendas = new List<Tienda>();
        List<Producto> Productos = new List<Producto>();
        
        public Persona CrearPersona(Persona p)
        {
            do
            {
                p.CodigoId = new Random().Next(1, 1000000000);
            }
            while (Usuarios.Where(g => g.CodigoId != p.CodigoId).Count() > 0);
            Usuarios.Add(p);
            return p;
        }

        public Producto CrearProducto(Producto p)
        {
            do
            {
                p.CodigoId = new Random().Next(1, 1000000000);
            }
            while (Productos.Where(g => g.CodigoId != p.CodigoId).Count() > 0);
            Productos.Add(p);
            return p;
        }

        public Tienda CrearTienda(Tienda t)
        {
            do
            {
                t.CodigoId = new Random().Next(1, 1000000000);
            }
            while (Tiendas.Where(g => g.CodigoId != t.CodigoId).Count() > 0);
            Tiendas.Add(t);
            return t;
        }

        public bool DeletePersona(Persona p)
        {
            try
            {
                var persona = Usuarios.FirstOrDefault(g => g.CodigoId == p.CodigoId);
                Usuarios.Remove(persona);
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
                var producto = Productos.FirstOrDefault(g => g.CodigoId == p.CodigoId);
                Productos.Remove(producto);
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
                var tienda = Tiendas.FirstOrDefault(g => g.CodigoId == t.CodigoId);
                Tiendas.Remove(tienda);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Persona GetPersona(int id)
        {
            return Usuarios.FirstOrDefault(g => g.CodigoId == id);
        }

        public List<Persona> GetPersonas()
        {
            throw new NotImplementedException();
        }

        public Producto GetProducto(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Tienda GetTienda(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tienda> GetTiendas()
        {
            throw new NotImplementedException();
        }

        public Persona ModificarPersona(Persona p)
        {
            var u = Usuarios.FirstOrDefault(g => g.CodigoId == p.CodigoId);
            u = p;
            return p;
        }

        public Producto ModificarProducto(Producto p)
        {
            throw new NotImplementedException();
        }

        public Tienda ModificarTienda(Tienda t)
        {
            throw new NotImplementedException();
        }
    }
}
