using System;
using System.Collections.Generic;
using Xunit;
using Restaurant.Entities;
using TestExam;

namespace TestDesafio
{
    public class TestMas
    {

        private readonly IDesafioTecnico _service;
        private readonly DesafioTecnicoImpl _mock;
        public TestMas()
        {
            // Replace with your actual implementation
            _service = new DesafioTecnico();
            _mock = new DesafioTecnicoImpl();
        }
        [Fact]
        public void CalcularTotalVenta_ReturnsCorrectTotal()
        {
            var sale = new Sale(DateTime.Now, "Cliente");
            sale.AddProduct(new Product(1, "Café", 10m));
            sale.AddProduct(new Product(2, "Té", 15m));
            Assert.Equal(25m, DesafioTecnicoMas.CalcularTotalVenta(sale));
            Assert.Equal(25m, _mock.CalcularTotalVenta(sale));
        }

        [Fact]
        public void FiltrarVentasSinProductos_FiltersCorrectly()
        {
            var sale1 = new Sale(DateTime.Now, "Cliente1");
            var sale2 = new Sale(DateTime.Now, "Cliente2");
            sale2.AddProduct(new Product(1, "Café", 10m));
            var sales = new List<Sale> { sale1, sale2 };
            var result = DesafioTecnicoMas.FiltrarVentasSinProductos(sales);
            Assert.Single(result);
            Assert.Equal("Cliente2", result[0].CustomerName);
            var result2 = _mock.FiltrarVentasSinProductos(sales);
            Assert.Single(result2);
            Assert.Equal("Cliente2", result2[0].CustomerName);
        }

        [Fact]
        public void ProductoMasVendido_ReturnsMostSoldProduct()
        {
            var sale1 = new Sale(DateTime.Now, "Cliente1");
            var sale2 = new Sale(DateTime.Now, "Cliente2");
            var p1 = new Product(1, "Café", 10m);
            var p2 = new Product(2, "Té", 15m);
            sale1.AddProduct(p1);
            sale1.AddProduct(p2);
            sale2.AddProduct(p1);
            var sales = new List<Sale> { sale1, sale2 };
            var mostSold = DesafioTecnicoMas.ProductoMasVendido(sales);
            Assert.NotNull(mostSold);
            Assert.Equal(1, mostSold.Id);
            Assert.Equal("Café", mostSold.Name);
            var mostSold2 = _mock.ProductoMasVendido(sales);
            Assert.NotNull(mostSold2);
            Assert.Equal(1, mostSold2.Id);
            Assert.Equal("Café", mostSold2.Name);
        }

        [Fact]
        public void TotalVendido_ReturnsSumOfAllSales()
        {
            var sale1 = new Sale(DateTime.Now, "Cliente1");
            var sale2 = new Sale(DateTime.Now, "Cliente2");
            sale1.AddProduct(new Product(1, "Café", 10m));
            sale2.AddProduct(new Product(2, "Té", 15m));
            var sales = new List<Sale> { sale1, sale2 };
            var total = DesafioTecnicoMas.TotalVendido(sales);
            Assert.Equal(25m, total);
            var total2 = _mock.TotalVendido(sales);
            Assert.Equal(25m, total2);
        }

        [Fact]
        public void TotalVendidoPorProducto_ReturnsCorrectTotal()
        {
            var p1 = new Product(1, "Café", 10m);
            var p2 = new Product(2, "Té", 15m);

            var sale1 = new Sale(DateTime.Now, "Cliente1");
            var sale2 = new Sale(DateTime.Now, "Cliente2");
            sale1.AddProduct(p1);
            sale1.AddProduct(p2);
            sale2.AddProduct(p1);

            var sales = new List<Sale> { sale1, sale2 };

            var total = DesafioTecnicoMas.TotalVendidoPorProducto(sales, p1);
            Assert.Equal(20m, total);

            var total2 = _mock.TotalVendidoPorProducto(sales, p1);
            Assert.Equal(20m, total2);
        }

        [Fact]
        public void TotalVendidoPorProducto_ReturnsZeroIfNotSold()
        {
            var p1 = new Product(1, "Café", 10m);
            var p2 = new Product(2, "Té", 15m);

            var sale1 = new Sale(DateTime.Now, "Cliente1");
            sale1.AddProduct(p2);

            var sales = new List<Sale> { sale1 };

            var total = DesafioTecnicoMas.TotalVendidoPorProducto(sales, p1);
            Assert.Equal(0m, total);

            var total2 = _mock.TotalVendidoPorProducto(sales, p1);
            Assert.Equal(0m, total2);
        }

        [Fact]
        public void TotalVendidoPorProducto_ThrowsOnNullVentas()
        {
            var p1 = new Product(1, "Café", 10m);
            Assert.Throws<ArgumentNullException>(() => DesafioTecnicoMas.TotalVendidoPorProducto(null, p1));
            Assert.Throws<ArgumentNullException>(() => _mock.TotalVendidoPorProducto(null, p1));
        }

        [Fact]
        public void TotalVendidoPorProducto_ThrowsOnNullProducto()
        {
            var sale1 = new Sale(DateTime.Now, "Cliente1");
            var sales = new List<Sale> { sale1 };
            Assert.Throws<ArgumentNullException>(() => DesafioTecnicoMas.TotalVendidoPorProducto(sales, null));
            Assert.Throws<ArgumentNullException>(() => _mock.TotalVendidoPorProducto(sales, null));
        }

        [Fact]
        public void CalcularTotalVenta_ThrowsOnNullSale()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnicoMas.CalcularTotalVenta(null));
            Assert.Throws<ArgumentNullException>(() => _mock.CalcularTotalVenta(null));
        }

        [Fact]
        public void FiltrarVentasSinProductos_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnicoMas.FiltrarVentasSinProductos(null));
            Assert.Throws<ArgumentNullException>(() => _mock.FiltrarVentasSinProductos(null));
        }

        [Fact]
        public void ProductoMasVendido_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnicoMas.ProductoMasVendido(null));
            Assert.Throws<ArgumentNullException>(() => _mock.ProductoMasVendido(null));
        }

        [Fact]
        public void TotalVendido_ThrowsOnNullList()
        {
            Assert.Throws<ArgumentNullException>(() => DesafioTecnicoMas.TotalVendido(null));
            Assert.Throws<ArgumentNullException>(() => _mock.TotalVendido(null));
        }
    }
}
