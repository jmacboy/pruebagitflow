using System;
using System.Collections.Generic;

namespace Pedidos.Application.Dto.Pedido
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public string NroPedido { get; set; }
        public decimal Total { get; set; }
        public ICollection<DetallePedidoDto> Detalle { get; set; }

        public PedidoDto()
        {
            Detalle = new List<DetallePedidoDto>();
        }
    }
}
