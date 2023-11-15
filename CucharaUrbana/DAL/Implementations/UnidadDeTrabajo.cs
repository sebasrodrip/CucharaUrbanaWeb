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
        public IPedidosDAL _pedidosDAL { get;  }
        public IReservacionDAL _reservacionDAL { get; }

       

        private readonly CucharaUrbana _context;

        public UnidadDeTrabajo(CucharaUrbana context,
                                IPedidosDAL pedidosDAL,
                                IReservacionDAL reservacionDAL)
        {
            _context = context;
            _pedidosDAL = pedidosDAL;
            _reservacionDAL = reservacionDAL;
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
