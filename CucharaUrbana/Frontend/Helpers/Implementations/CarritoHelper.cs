using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class CarritoHelper : ICarritoHelper
    {

        IServiceRepository _repository;

        public CarritoHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public CarritoViewModel AddCarrito(CarritoViewModel carritoViewModel)
        {

            CarritoViewModel carrito = new CarritoViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Carrito", carritoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);
            }

            return carrito;
        }

        public void DeleteCarrito(int id)
        {

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Carrito/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public CarritoViewModel EditCarrito(CarritoViewModel carritoViewModel)
        {

            CarritoViewModel carrito = new CarritoViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Carrito", carritoViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);
            }

            return carrito;
        }

        public List<CarritoViewModel> GetAll()
        {

            List<CarritoViewModel> lista = new List<CarritoViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Carrito");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CarritoViewModel>>(content);
            }

            return lista;
        }

        public CarritoViewModel GetById(int id)
        {
            CarritoViewModel carrito = new CarritoViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Carrito/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);
            }

            return carrito;
        }
    }
}
