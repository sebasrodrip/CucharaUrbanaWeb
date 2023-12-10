using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IPedidoHelper
    {
        List<PedidoViewModel> GetAll();
        PedidoViewModel GetById(int id);
        PedidoViewModel AddPedido(PedidoViewModel pedidoViewModel);
        PedidoViewModel EditPedido(PedidoViewModel pedidoViewModel);

        void DeletePedido(int id);

    }
}
