using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class FacturaHelper : IFacturaHelper
    {

        IServiceRepository _repository;

        public FacturaHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public FacturaViewModel AddFactura(FacturaViewModel facturaViewModel)
        {

            FacturaViewModel factura = new FacturaViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Factura",facturaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<FacturaViewModel>(content);
            }

            return factura;
        }

        public void DeleteFactura(int id)
        {
           
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Factura/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                
            }

            
        }

        public FacturaViewModel EditFactura(FacturaViewModel facturaViewModel)
        {

            FacturaViewModel factura = new FacturaViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Factura", facturaViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<FacturaViewModel>(content);
            }

            return factura;
        }

        public List<FacturaViewModel> GetAll()
        {

            List<FacturaViewModel> lista = new List<FacturaViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Factura");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<FacturaViewModel>>(content);
            }

            return lista;
        }

        public FacturaViewModel GetById(int id)
        {
            FacturaViewModel factura = new FacturaViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Factura/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<FacturaViewModel>(content);
            }

            return factura;
        }
    }
}
