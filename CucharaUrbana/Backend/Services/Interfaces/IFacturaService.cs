using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<Factura>> GetFacturaAsync();
        Factura GetById(int id);
        bool AddFactura(Factura factura);
        bool UpdateFactura(Factura factura);
        bool DeleteFactura(Factura factura);


    }
}
