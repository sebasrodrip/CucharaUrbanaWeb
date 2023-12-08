using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ProductoService : IProductoService
    {

        IUnidadDeTrabajo _unidadDeTrabajo;
        public ProductoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public Task<bool> Add(Producto producto)
        {
            try
            {
                _unidadDeTrabajo._productoDAL.Add(producto);
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
                Producto producto = new Producto { ProductoId = id };

                _unidadDeTrabajo._productoDAL.Remove(producto);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);

            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Producto> GetById(int id)
        {
            Producto producto = _unidadDeTrabajo._productoDAL.Get(id);
            return producto;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            IEnumerable<Producto> productos = await _unidadDeTrabajo._productoDAL.GetAll();
            return productos;
        }

        public Task<bool> Update(Producto producto)
        {
            try
            {
                _unidadDeTrabajo._productoDAL.Update(producto);
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
