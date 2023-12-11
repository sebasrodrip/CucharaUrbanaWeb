using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class PedidoService : IPedidoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PedidoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddPedido(Pedido pedido)
        {
            bool resultado = _unidadDeTrabajo._pedidosDAL.Add(pedido);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeletePedido(Pedido pedido)
        {
            bool resultado = _unidadDeTrabajo._pedidosDAL.Remove(pedido);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Pedido GetById(int id)
        {
            Pedido pedido;
            pedido = _unidadDeTrabajo._pedidosDAL.Get(id);
            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            IEnumerable<Pedido> pedidos;
            pedidos = await _unidadDeTrabajo._pedidosDAL.GetAll();
            return pedidos;
        }

        public bool UpdatePedido(Pedido pedido)
        {
            bool resultado = _unidadDeTrabajo._pedidosDAL.Update(pedido);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
