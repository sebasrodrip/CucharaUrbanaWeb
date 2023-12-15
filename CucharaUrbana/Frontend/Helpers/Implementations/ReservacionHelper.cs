using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations
{
    public class ReservacionHelper : IReservacionHelper
    {

        IServiceRepository _repository;
        public string Token { get; set; }

        public ReservacionHelper(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        public ReservacionViewModel AddReservacion(ReservacionViewModel reservacionViewModel)
        {

            ReservacionViewModel reservacion = new ReservacionViewModel();
            HttpResponseMessage responseMessage = _repository.PostResponse("api/Reservacion", reservacionViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                reservacion = JsonConvert.DeserializeObject<ReservacionViewModel>(content);
            }

            return reservacion;
        }

        public void DeleteReservacion(int id)
        {

            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Reservacion/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }


        }

        public ReservacionViewModel EditReservacion(ReservacionViewModel reservacionViewModel)
        {

            ReservacionViewModel reservacion = new ReservacionViewModel();
            HttpResponseMessage responseMessage = _repository.PutResponse("api/Reservacion", reservacionViewModel);
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                reservacion = JsonConvert.DeserializeObject<ReservacionViewModel>(content);
            }

            return reservacion;
        }

        public List<ReservacionViewModel> GetAll()
        {

            List<ReservacionViewModel> lista = new List<ReservacionViewModel>();

            HttpResponseMessage responseMessage = _repository.GetResponse("api/Reservacion");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ReservacionViewModel>>(content);
            }

            return lista;
        }

        public ReservacionViewModel GetById(int id)
        {
            ReservacionViewModel reservacion = new ReservacionViewModel();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/Reservacion/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                reservacion = JsonConvert.DeserializeObject<ReservacionViewModel>(content);
            }

            return reservacion;
        }
    }
}
