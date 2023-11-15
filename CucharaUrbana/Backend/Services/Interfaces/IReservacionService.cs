using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IReservacionService
    {
        Task<IEnumerable<Reservacion>> GetProducts();
        Task<bool> Add(Reservacion reservacion);
        Task<bool> Update(Reservacion reservacion);
        Task<bool> Delete(int id); 
        Task<Reservacion> GetById(int id);
        

    }
}
