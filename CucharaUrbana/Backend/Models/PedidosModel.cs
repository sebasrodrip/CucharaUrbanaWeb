namespace BackEnd.Models
{
    public class PedidosModel
    {

        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int MesaPedido { get; set; }
        public int UsuarioID { get; set; }
        public string? EstadoPedido { get; set; }
        public int ProductoID { get; set; }


    }
}
