﻿using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Carrito
    {
        public Carrito()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Producto Producto { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
