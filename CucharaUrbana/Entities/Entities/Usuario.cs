using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Facturas = new HashSet<Factura>();
            Pedidos = new HashSet<Pedido>();
            Reservacions = new HashSet<Reservacion>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public int? RolId { get; set; }

        public virtual Rol? Rol { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Reservacion> Reservacions { get; set; }
    }
}
