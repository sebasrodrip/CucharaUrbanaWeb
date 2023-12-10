namespace FrontEnd.Models
{
    public class ReservacionViewModel
    {

        public int ReservacionId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int MesaReservacion { get; set; }
        public TimeOnly HoraReservacion { get; set; }
        public int DetalleReservacion { get; set; }
    }
}
