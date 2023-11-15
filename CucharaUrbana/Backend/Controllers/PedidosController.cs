using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        public IPedidosService _pedidosService;

        private Pedidos Convertir(PedidosModel pedidos)
        {
            return new Pedidos
            {
                PedidoId = pedidos.PedidoId,
                FechaPedido = pedidos.FechaPedido,
                MesaPedido = pedidos.MesaPedido,
                UsuarioID = pedidos.UsuarioID,
                EstadoPedido = pedidos.EstadoPedido,
                ProductoID = pedidos.ProductoID
            };
        
        }


        private PedidosModel Convertir(PedidosController pedidos)
        {
            return new PedidosModel
            {
                PedidoId = pedidos.PedidoId,
                FechaPedido = pedidos.FechaPedido,
                MesaPedido = pedidos.MesaPedido,
                UsuarioID = pedidos.UsuarioID,
                EstadoPedido = pedidos.EstadoPedido,
                ProductoID = pedidos.ProductoID
            };

        }

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

     
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Pedidos> lista = _pedidosService.GetPedidosAsync().Result; 
            List<PedidosModel> pedidos =  new List<PedidosModel>();

            foreach (var item in lista)
            {
                pedidos.Add(Convertir(item));

            }

            return Ok(pedidos);
        }

     
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pedidos pedidos = _pedidosService.GetById(id);
            PedidosModel pedidosModel = Convertir(pedidos);

            return Ok(pedidosModel);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PedidosModel pedidos)
        {
            Pedidos entity = Convertir(pedidos);
            _pedidosService.AddPedidos(entity);
            return Ok(Convertir(entity));

        }

 
        [HttpPut]
        public IActionResult Put( [FromBody] PedidosModel pedidos)
        {
            Pedidos entity = Convertir(pedidos);
            _pedidosService.UpdatePedidos(entity);
            return Ok(Convertir(entity));
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pedidos pedidos = new Pedidos
            {
                PedidoId = id
            };

            _pedidosService.DetelePedidos(pedidos);

            return Ok();
        }
    }
}
