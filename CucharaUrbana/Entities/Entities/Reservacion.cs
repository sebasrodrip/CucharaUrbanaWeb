using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Reservacion
    {
        public int ReservacionId { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int MesaReservacion { get; set; }
        public int DetalleReservacion { get; set; }
    }
}
