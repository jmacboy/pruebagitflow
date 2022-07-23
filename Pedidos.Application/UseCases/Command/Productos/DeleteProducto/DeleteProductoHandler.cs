using MediatR;
using Microsoft.Extensions.Logging;
using Pedidos.Domain.Factories;
using Pedidos.Domain.Model.Productos;
using Pedidos.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pedidos.Application.UseCases.Command.Productos.CrearProducto
{

    public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand, bool>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<DeleteProductoHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductoHandler(IProductoRepository productoRepository, ILogger<DeleteProductoHandler> logger, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Producto objProducto = await _productoRepository.FindByIdAsync(request.Id);
                objProducto.DeleteProducto();
                await _productoRepository.RemoveAsync(objProducto);
                await _unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar producto");
            }
            return false;
        }
    }
}
