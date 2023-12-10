using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IReservacionHelper
    {
        List<ReservacionViewModel> GetAll();
        ReservacionViewModel GetById(int id);
        ReservacionViewModel AddReservacion(ReservacionViewModel reservacionViewModel);
        ReservacionViewModel EditReservacion(ReservacionViewModel reservacionViewModel);

        void DeleteReservacion(int id);

    }
}
