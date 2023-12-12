using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IReservacionHelper
    {
        List<ReservacionViewModel> GetAll();
        ReservacionViewModel GetById(int id);
        ReservacionViewModel AddReservacion(ReservacionViewModel ReservacionViewModel);
        ReservacionViewModel EditReservacion(ReservacionViewModel ReservacionViewModel);

        void DeleteReservacion(int id);

    }
}
