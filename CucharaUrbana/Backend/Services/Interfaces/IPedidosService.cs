using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IPedidosService
    {
        Task<IEnumerable<Pedidos>> GetPedidosAsync();
        Pedidos GetById(int id);
        bool AddPedidos(Pedidos pedidos);
        bool UpdatePedidos(Pedidos pedidos);
        bool DetelePedidos(Pedidos pedidos);


    }
}
