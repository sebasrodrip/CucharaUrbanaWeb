using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface ICarritoService
    {
        Task<IEnumerable<Carrito>> GetCarritos();
        Task<Carrito> GetById(int id);
        Task<bool> Add(Carrito carrito);
        Task<bool> Update(Carrito carrito);
        Task<bool> Delete(int id);


    }
}
