using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ReservacionService : IReservacionService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ReservacionService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddReservacion(Reservacion reservacion)
        {
            bool resultado = _unidadDeTrabajo._reservacionDAL.Add(reservacion);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeleteReservacion(Reservacion reservacion)
        {
            bool resultado = _unidadDeTrabajo._reservacionDAL.Remove(reservacion);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Reservacion GetById(int id)
        {
            Reservacion reservacion;
            reservacion = _unidadDeTrabajo._reservacionDAL.Get(id);
            return reservacion;
        }

        public async Task<IEnumerable<Reservacion>> GetReservacionAsync()
        {
            IEnumerable<Reservacion> reservaciones;
            reservaciones = await _unidadDeTrabajo._reservacionDAL.GetAll();
            return reservaciones;
        }

        public bool UpdateReservacion(Reservacion reservacion)
        {
            bool resultado = _unidadDeTrabajo._reservacionDAL.Update(reservacion);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
