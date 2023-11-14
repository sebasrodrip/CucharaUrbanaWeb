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
        public IRolDAL _categoryDAL { get;  }
        public IShipperDAL _shipperDAL { get; }



        private readonly NorthWindContext _context;

        public UnidadDeTrabajo(NorthWindContext context,
                                IRolDAL categoryDAL,
                                IShipperDAL shipperDAL)
        {
            _context = context;
            _categoryDAL = categoryDAL;
            _shipperDAL = shipperDAL;
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
