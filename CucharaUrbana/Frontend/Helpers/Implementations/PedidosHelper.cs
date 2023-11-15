using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PedidosHelper : IPedidosHelper
    {

        IServiceRepository _repository;

        public PedidosHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public PedidosViewModel AddPedidos(PedidosViewModel pedidosViewModel)
        {

            PedidosViewModel pedidos = new PedidosViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Pedidos", pedidosViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                pedidos = JsonConvert.DeserializeObject<PedidosViewModel>(content);
            }

            return pedidos;
        }

        public void DeletePedidos(int id)
        {
           
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Pedidos/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                
            }

            
        }

        public PedidosViewModel EditPedidos(PedidosViewModel pedidosViewModel)
        {

            PedidosViewModel pedidos = new PedidosViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Pedidos", pedidosViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                pedidos = JsonConvert.DeserializeObject<PedidosViewModel>(content);
            }

            return pedidos;
        }

        public List<PedidosViewModel> GetAll()
        {

            List<PedidosViewModel> lista = new List<PedidosViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Pedidos");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<PedidosViewModel>>(content);
            }

            return lista;
        }

        public PedidosViewModel GetById(int id)
        {
            PedidosViewModel pedidos = new PedidosViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Pedidos/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                pedidos = JsonConvert.DeserializeObject<PedidosViewModel>(content);
            }

            return pedidos;
        }
    }
}
