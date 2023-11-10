using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Reservacion
    {
        public int ReservacionId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int MesaReservacion { get; set; }
        public TimeSpan HoraReservacion { get; set; }
        public int DetalleReservacion { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
