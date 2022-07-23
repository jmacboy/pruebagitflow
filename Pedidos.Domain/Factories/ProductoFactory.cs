using Pedidos.Domain.Model.Productos;

namespace Pedidos.Domain.Factories
{
    public class ProductoFactory : IProductoFactory
    {
        public Producto Create(string nombre, decimal precioVenta, int stockActual)
        {
            return new Producto(nombre, precioVenta, stockActual);
        }
    }
}
