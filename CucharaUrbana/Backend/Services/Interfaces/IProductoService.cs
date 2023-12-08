using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetById(int id);
        Task<bool> Add(Producto producto);
        Task<bool> Update(Producto producto);
        Task<bool> Delete(int id);


    }
}
