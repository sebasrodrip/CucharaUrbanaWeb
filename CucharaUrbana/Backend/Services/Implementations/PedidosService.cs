using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PedidosService : IPedidosService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public PedidosService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddPedidos(Pedidos pedidos)
        {
            bool resultado =_unidadDeTrabajo._pedidosDAL.Add(pedidos);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DetelePedidos(Pedidos pedidos)
        {
            bool resultado = _unidadDeTrabajo._pedidosDAL.Remove(pedidos);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Pedidos GetById(int id)
        {
            Pedidos pedidos;
            pedidos =  _unidadDeTrabajo._pedidosDAL.Get(id);
            return pedidos;
        }

        public async Task<IEnumerable<Pedidos>> GetPedidosAsync()
        {
            IEnumerable<Pedidos> pedidos;
            pedidos = await _unidadDeTrabajo._pedidosDAL.GetAll();
            return pedidos;
        }

        public bool UpdatePedidos(Pedidos pedidos)
        {
            bool resultado = _unidadDeTrabajo._pedidosDAL.Update(pedidos);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
