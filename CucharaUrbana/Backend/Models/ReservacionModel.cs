using Entities.Entities;

namespace Backend.Models
{
    public class ReservacionModel
    {

        public int ReservacionId { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int MesaReservacion { get; set; }
        public int DetalleReservacion { get; set; }


    }
}
