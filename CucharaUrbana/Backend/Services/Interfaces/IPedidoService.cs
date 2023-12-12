using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> GetById(int id);
        Task<bool> AddPedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(int id);


    }
}
