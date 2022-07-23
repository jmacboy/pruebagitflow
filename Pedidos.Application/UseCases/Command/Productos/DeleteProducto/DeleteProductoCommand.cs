using MediatR;
using System;

namespace Pedidos.Application.UseCases.Command.Productos.CrearProducto
{
    public class DeleteProductoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        private DeleteProductoCommand() { }

        public DeleteProductoCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
