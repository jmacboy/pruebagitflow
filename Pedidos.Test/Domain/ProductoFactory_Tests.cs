﻿using Pedidos.Domain.Factories;
using System;
using Xunit;

namespace Pedidos.Test.Domain
{
    public class ProductoFactory_Tests
    {
        [Fact]
        public void Create_Correctly()
        {
            String nombreTest = "Silla";
            decimal precioTest = 50;
            int stockTest = 5;
            var factory = new ProductoFactory();
            var producto = factory.Create(nombreTest, 50, 5);

            Assert.NotNull(producto);
            Assert.Equal(nombreTest, producto.Nombre);
            Assert.Equal(precioTest, (decimal)producto.PrecioVenta);
            Assert.Equal(stockTest, (int)producto.StockActual);
        }
    }
}
