using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPedidosHelper
    {
        List<PedidosViewModel> GetAll();
        PedidosViewModel GetById(int id);
        PedidosViewModel AddPedidos(PedidosViewModel pedidosViewModel);
        PedidosViewModel EditPedidos(PedidosViewModel pedidosViewModel);

        void DeletePedidos(int id);

    }
}
