using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IReservacionService
    {
        Task<IEnumerable<Reservacion>> GetReservacionAsync();
        Reservacion GetById(int id);
        bool AddReservacion(Reservacion reservacion);
        bool UpdateReservacion(Reservacion reservacion);
        bool DeleteReservacion(Reservacion reservacion);


    }
}
