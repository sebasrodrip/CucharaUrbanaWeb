using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoriumHelper : ICategoriumHelper
    {

        IServiceRepository _repository;

        public CategoriumHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public CategoriumViewModel AddCategorium(CategoriumViewModel categoriumViewModel)
        {

            CategoriumViewModel categorium = new CategoriumViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Categorium",categoriumViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categorium = JsonConvert.DeserializeObject<CategoriumViewModel>(content);
            }

            return categorium;
        }

        public void DeleteCategorium(int id)
        {
           
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Categorium/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                
            }

            
        }

        public CategoriumViewModel EditCategorium(CategoriumViewModel categoriumViewModel)
        {

            CategoriumViewModel categorium = new CategoriumViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Categorium", categoriumViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categorium = JsonConvert.DeserializeObject<CategoriumViewModel>(content);
            }

            return categorium;
        }

        public List<CategoriumViewModel> GetAll()
        {

            List<CategoriumViewModel> lista = new List<CategoriumViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Categorium");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CategoriumViewModel>>(content);
            }

            return lista;
        }

        public CategoriumViewModel GetById(int id)
        {
            CategoriumViewModel categorium = new CategoriumViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Categorium/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categorium = JsonConvert.DeserializeObject<CategoriumViewModel>(content);
            }

            return categorium;
        }
    }
}
