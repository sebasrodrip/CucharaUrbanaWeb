using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public IFacturaDAL _facturaDAL { get; }
        public ICategoriumDAL _categoriumDAL { get; }
        public IProductoDAL _productoDAL { get; }
        public IPedidoDAL _pedidosDAL { get;  }
        public IReservacionDAL _reservacionDAL { get; }

        public ICarritoDAL _carritoDAL { get; }

        private readonly CucharaUrbanaContext _context;

        public UnidadDeTrabajo(CucharaUrbanaContext context,
                                IFacturaDAL facturaDAL,
                                IProductoDAL productoDAL,
                                ICategoriumDAL categoriumDAL,
                                IPedidoDAL pedidosDAL,
                                IReservacionDAL reservacionDAL,
                                ICarritoDAL carritoDAL)
        {
            _context = context;
            _facturaDAL = facturaDAL;
            _categoriumDAL = categoriumDAL;
            _productoDAL = productoDAL;
            _pedidosDAL = pedidosDAL;
            _reservacionDAL = reservacionDAL;
            _carritoDAL = carritoDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;

            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
