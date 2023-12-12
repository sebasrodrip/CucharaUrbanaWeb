using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class CarritoService : ICarritoService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;
        public CarritoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public Task<bool> Add(Carrito carrito)
        {
            try
            {
                _unidadDeTrabajo._carritoDAL.Add(carrito);
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
                Carrito carrito = new Carrito { CarritoId = id };

                _unidadDeTrabajo._carritoDAL.Remove(carrito);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);

            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Carrito> GetById(int id)
        {
            Carrito carrito = _unidadDeTrabajo._carritoDAL.Get(id);
            return carrito;
        }

        public async Task<IEnumerable<Carrito>> GetCarritos()
        {
                IEnumerable<Carrito> carritos = await _unidadDeTrabajo._carritoDAL.GetAll();
                return carritos;
        }

        public Task<bool> Update(Carrito carrito)
        {
            try
            {
                _unidadDeTrabajo._carritoDAL.Update(carrito);
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
