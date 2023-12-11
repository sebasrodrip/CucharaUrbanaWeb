using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class PedidoHelper : IPedidoHelper
    {

        IServiceRepository _repository;

        public PedidoHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public PedidoViewModel AddPedido(PedidoViewModel pedidoViewModel)
        {

            PedidoViewModel pedido = new PedidoViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Pedido", pedidoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                pedido = JsonConvert.DeserializeObject<PedidoViewModel>(content);
            }

            return pedido;
        }

        public void DeletePedido(int id)
        {

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Pedido/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public PedidoViewModel EditPedido(PedidoViewModel pedidoViewModel)
        {

            PedidoViewModel pedido = new PedidoViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Pedido", pedidoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                pedido = JsonConvert.DeserializeObject<PedidoViewModel>(content);
            }

            return pedido;
        }

        public List<PedidoViewModel> GetAll()
        {

            List<PedidoViewModel> lista = new List<PedidoViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Pedido");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<PedidoViewModel>>(content);
            }

            return lista;
        }

        public PedidoViewModel GetById(int id)
        {
            PedidoViewModel pedido = new PedidoViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Pedido/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                pedido = JsonConvert.DeserializeObject<PedidoViewModel>(content);
            }

            return pedido;
        }
    }
}
