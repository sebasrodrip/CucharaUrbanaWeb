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

        public Task<bool> Add(Factura factura)
        {           
            try
            {
                _unidadDeTrabajo._facturaDAL.Add(factura);
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
                Factura facturas = new Factura { FacturaId = id };

                _unidadDeTrabajo._facturaDAL.Remove(facturas);
                _unidadDeTrabajo.Complete();
                return Task.FromResult(true);

            }
            catch (Exception)
            {

                return Task.FromResult(false); ;
            }
        }

        public async Task<Factura> GetById(int id)
        {
            Factura factura = _unidadDeTrabajo._facturaDAL.Get(id);
            return factura;
        }

        public async Task<IEnumerable<Factura>> GetFactura()
        {
            IEnumerable<Factura> facturas = await _unidadDeTrabajo._facturaDAL.GetAll();
            return facturas;
        }

        public Task<bool> Update(Factura factura)
        {
            try
            {
                _unidadDeTrabajo._facturaDAL.Update(factura);
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
