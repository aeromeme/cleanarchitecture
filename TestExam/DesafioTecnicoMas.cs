using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Entities;

namespace TestExam
{
    public static class DesafioTecnicoMas
    {
        // Calcula el total de una venta
        public static decimal CalcularTotalVenta(Sale sale)
        {
            if (sale == null)
                throw new ArgumentNullException(nameof(sale));
            return sale.Products.Sum(p => p.Price);
        }

        // Filtra las ventas que no tienen productos
        public static List<Sale> FiltrarVentasSinProductos(IEnumerable<Sale> ventas)
        {
            if (ventas == null)
                throw new ArgumentNullException(nameof(ventas));
            return ventas.Where(v => v.Products != null && v.Products.Count > 0).ToList();
        }

        // Obtiene el producto más vendido en un listado de ventas
        public static Product ProductoMasVendido(IEnumerable<Sale> ventas)
        {
            if (ventas == null)
                throw new ArgumentNullException(nameof(ventas));

            // Agrupa todos los productos por Id y cuenta la cantidad
            var productoMasVendido = ventas
                .SelectMany(v => v.Products ?? new List<Product>())
                .GroupBy(p => p.Id)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault())
                .FirstOrDefault();

            return productoMasVendido;
        }

        public static decimal TotalVendido(IEnumerable<Sale> ventas)
        {
            if (ventas == null)
                throw new ArgumentNullException(nameof(ventas));
            return ventas.Sum(v => v.GetTotal());
        }

        public static decimal TotalVendidoPorProducto(IEnumerable<Sale> ventas, Product producto)
        {
            if (ventas == null)
                throw new ArgumentNullException(nameof(ventas));
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            return ventas
                .SelectMany(v => v.Products ?? new List<Product>())
                .Where(p => p.Id == producto.Id)
                .Sum(p => p.Price);
        }
    }
}
