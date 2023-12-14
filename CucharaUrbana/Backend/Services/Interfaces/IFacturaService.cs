using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<Factura>> GetFactura();
        Task <Factura> GetById(int id);
        Task<bool> Add(Factura factura);
        Task<bool> Update(Factura factura);
        Task<bool> Delete(int id);


    }
}
