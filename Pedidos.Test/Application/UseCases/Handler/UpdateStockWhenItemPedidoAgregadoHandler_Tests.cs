using Moq;
using Pedidos.Domain.Repositories;
using Xunit;

namespace Pedidos.Test.Application.UseCases.Handler
{
    public class UpdateStockWhenItemPedidoAgregadoHandler_Tests
    {
        private readonly Mock<IProductoRepository> productoRepository;
        public UpdateStockWhenItemPedidoAgregadoHandler_Tests()
        {
            productoRepository = new Mock<IProductoRepository>();
        }

        [Fact]
        public void UpdateStockWhenItemPedidoAgregadoHandler_HandleCorrectly()
        {

        }
    }
}
