using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOnline.Models
{
    public interface IDeliveryContext
    {
        List<Persona> GetPersonas();
        List<Producto> GetProductos();
        List<Tienda> GetTiendas();

        List<Pedido> GetPedidos();
        List<DetallePedido> GetDetallePedidos();
        List<Venta> GetVentas();
        List<DetalleVenta> GetDetalleVentas();

        Persona CrearPersona(Persona p);
        Producto CrearProducto(Producto p);
        Tienda CrearTienda(Tienda t);

        Pedido CrearPedido(Pedido p);
        DetallePedido AgregarDetallePedido(DetallePedido dp);
        Venta CrearVenta(Venta p);
        DetalleVenta AgregarDetalleVenta(DetalleVenta dp);



        bool DeletePersona(Persona p);
        bool DeleteProducto(Producto p);
        bool DeleteTienda(Tienda t);

        bool DeletePedido(Pedido p);
        bool QuitarDetallePedido(DetallePedido dp);
        bool DeleteVenta(Venta v);
        bool QuitarDetalleVenta(DetalleVenta dv);


        Persona ModificarPersona(Persona p);
        Producto ModificarProducto(Producto p);
        Tienda ModificarTienda(Tienda t);

        Pedido ModificarPedido(Pedido t);
        Venta ModificarVenta(Venta t);

        Persona GetPersona(int id);
        Producto GetProducto(int id);
        Tienda GetTienda(int id);

        Pedido GetPedido(int id);
        DetallePedido GetDetallePedido(int id,Producto producto);
        Venta GetVenta(int id);
        DetalleVenta GetDetalleVenta(int id, Producto producto);

    }
}
