using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ProductoService : IProductoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public ProductoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddProducto(Producto productos)
        {
            bool resultado =_unidadDeTrabajo._productoDAL.Add(productos);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeleteProducto(Producto productos)
        {
            bool resultado = _unidadDeTrabajo._productoDAL.Remove(productos);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Producto GetById(int id)
        {
            Producto productos;
            productos =  _unidadDeTrabajo._productoDAL.Get(id);
            return productos;
        }

        public async Task<IEnumerable<Producto>> GetProductoAsync()
        {
            IEnumerable<Producto> productos;
            productos = await _unidadDeTrabajo._productoDAL.GetAll();
            return productos;
        }

        public bool UpdateProducto(Producto productos)
        {
            bool resultado = _unidadDeTrabajo._productoDAL.Update(productos);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
