using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ReservacionService : IReservacionService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public ReservacionService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public Task<bool> Add(Reservacion reservacion)
        {
            try
            {
                _unidadDeTrabajo._productDAL.Add(reservacion);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
          
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                Reservacion reservacion = new Reservacion { ReservacionId = id };

                _unidadDeTrabajo._reservacionDAL.Remove(reservacion);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            
            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Reservacion> GetById(int id)
        {
            Reservacion reservacion = _unidadDeTrabajo._reservacionDAL.Get(id);
            return reservacion;
        }

        public async Task<IEnumerable<Reservacion>> GetProducts()
        {
            IEnumerable<Reservacion> reservacion = await _unidadDeTrabajo._reservacionDAL.GetAll();
            return reservacion;
        }

        public Task<bool> Update(Reservacion reservacion)
        {
            try
            {
                _unidadDeTrabajo._reservacionDAL.Update(reservacion);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            
        }
    }
}
