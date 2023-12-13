using Entities.Entities;

namespace Frontend.Models
{
    public class ReservacionViewModel
    {

        public int ReservacionId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int MesaReservacion { get; set; }
        public TimeSpan HoraReservacion { get; set; }
        public int DetalleReservacion { get; set; }

    }
}
