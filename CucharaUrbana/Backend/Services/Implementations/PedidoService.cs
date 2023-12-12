using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class PedidoService : IPedidoService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;
        public PedidoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public Task<bool> AddPedido(Pedido pedido)
        {
            try
            {
                _unidadDeTrabajo._pedidosDAL.Add(pedido);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

        }

        public Task<bool> DeletePedido(int id)
        {
            try
            {
                Pedido pedido = new Pedido { PedidoId = id };

                _unidadDeTrabajo._pedidosDAL.Remove(pedido);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);

            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Pedido> GetById(int id)
        {
            Pedido pedido = _unidadDeTrabajo._pedidosDAL.Get(id);
            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            IEnumerable<Pedido> pedidos = await _unidadDeTrabajo._pedidosDAL.GetAll();
            return pedidos;
        }

        public Task<bool> UpdatePedido(Pedido pedido)
        {
            try
            {
                _unidadDeTrabajo._pedidosDAL.Update(pedido);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }
    }
}
