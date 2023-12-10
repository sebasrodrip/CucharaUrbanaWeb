using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Pedido GetById(int id);
        bool AddPedido(Pedido pedido);
        bool UpdatePedido(Pedido pedido);
        bool DeletePedido(Pedido pedido);


    }
}
