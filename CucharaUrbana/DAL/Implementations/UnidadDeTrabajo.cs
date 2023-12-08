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
        public IProductoDAL _productoDAL { get; }

        private readonly CucharaUrbanaContext _context;

        public UnidadDeTrabajo(CucharaUrbanaContext context,
                                IFacturaDAL facturaDAL)
        {
            _context = context;
            _facturaDAL = facturaDAL;
        
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
