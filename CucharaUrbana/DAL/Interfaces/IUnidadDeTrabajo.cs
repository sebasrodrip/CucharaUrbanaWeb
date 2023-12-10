﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {

        IFacturaDAL _facturaDAL { get; }
        IRolDAL _rolDAL { get; }
        ICategoriumDAL _categoriumDAL { get; }
        
        bool Complete();
    }
}
