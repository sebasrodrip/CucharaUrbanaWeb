﻿using DAL.Interfaces;
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
        public IRolDAL _rolDAL { get;  }
        public ICategoriumDAL _categoriumDAL { get; }
        public IProductoDAL _productoDAL { get; }
        public IPedidoDAL _pedidosDAL { get;  }
        /*public IReservacionDAL _reservacionDAL { get; }*/

        private readonly CucharaUrbanaContext _context;

        public UnidadDeTrabajo(CucharaUrbanaContext context,
                                IFacturaDAL facturaDAL,
                                IProductoDAL productoDAL,
                                IRolDAL rolDAL,
                                ICategoriumDAL categoriumDAL,
                                IPedidoDAL pedidosDAL
                                /*IReservacionDAL reservacionDAL*/)
        {
            _context = context;
            _facturaDAL = facturaDAL;
            _rolDAL = rolDAL;
            _categoriumDAL = categoriumDAL;
            _productoDAL = productoDAL;
            _pedidosDAL = pedidosDAL;
            /*_reservacionDAL = reservacionDAL*/;        
     
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
