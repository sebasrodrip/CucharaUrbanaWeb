using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class FacturaDALImpl : DALGenericoImpl<Factura>, IFacturaDAL
    {
        public FacturaDALImpl(CucharaUrbanaContext context): base(context)
            { 
        
            }
    }
}
