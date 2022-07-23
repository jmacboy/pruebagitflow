using ShareKernel.Core;
using System;

namespace Pedidos.Domain.Event
{
    public record ProductoEliminado : DomainEvent
    {
        public Guid ProductoId { get; }
        public ProductoEliminado(Guid productoId) : base(DateTime.Now)
        {
            ProductoId = productoId;


        }
    }
}
