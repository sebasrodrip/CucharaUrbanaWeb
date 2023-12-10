using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class RolHelper : IRolHelper
    {

        IServiceRepository _repository;

        public RolHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public RolViewModel AddRol(RolViewModel rolViewModel)
        {

            RolViewModel rol = new RolViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Rol", rolViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<RolViewModel>(content);
            }

            return rol;
        }

        public void DeleteRol(int id)
        {

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Rol/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public RolViewModel EditRol(RolViewModel rolViewModel)
        {

            RolViewModel rol = new RolViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Rol", rolViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<RolViewModel>(content);
            }

            return rol;
        }

        public List<RolViewModel> GetAll()
        {

            List<RolViewModel> lista = new List<RolViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Rol");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<RolViewModel>>(content);
            }

            return lista;
        }

        public RolViewModel GetById(int id)
        {
            RolViewModel rol = new RolViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Rol/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                rol = JsonConvert.DeserializeObject<RolViewModel>(content);
            }

            return rol;
        }
    }
}
