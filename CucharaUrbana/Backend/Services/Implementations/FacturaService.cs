using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class FacturaService : IFacturaService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public FacturaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool AddFactura(Factura facturas)
        {
            bool resultado =_unidadDeTrabajo._facturaDAL.Add(facturas);
            _unidadDeTrabajo.Complete();

            return resultado;

        }

        public bool DeleteFactura(Factura facturas)
        {
            bool resultado = _unidadDeTrabajo._facturaDAL.Remove(facturas);
            _unidadDeTrabajo.Complete();

            return resultado;
        }

        public Factura GetById(int id)
        {
            Factura facturas;
            facturas =  _unidadDeTrabajo._facturaDAL.Get(id);
            return facturas;
        }

        public async Task<IEnumerable<Factura>> GetFacturaAsync()
        {
            IEnumerable<Factura> facturas;
            facturas = await _unidadDeTrabajo._facturaDAL.GetAll();
            return facturas;
        }

        public bool UpdateFactura(Factura facturas)
        {
            bool resultado = _unidadDeTrabajo._facturaDAL.Update(facturas);
            _unidadDeTrabajo.Complete();

            return resultado;
        }
    }
}
