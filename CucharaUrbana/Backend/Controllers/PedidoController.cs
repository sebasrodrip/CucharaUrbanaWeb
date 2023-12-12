using Backend.Models;
using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        public IPedidoService _pedidoService;

        private Pedido Convertir(PedidoModel pedido)
        {
            return new Pedido
            {
                PedidoId = pedido.PedidoId,
                FechaPedido = pedido.FechaPedido,
                MesaPedido = pedido.MesaPedido,
                UsuarioId = pedido.UsuarioId,
                EstadoPedido = pedido.EstadoPedido,
                ProductoId = pedido.ProductoId
            };

        }


        private PedidoModel Convertir(Pedido pedido)
        {
            return new PedidoModel
            {
                PedidoId = pedido.PedidoId,
                FechaPedido = pedido.FechaPedido,
                MesaPedido = pedido.MesaPedido,
                UsuarioId = pedido.UsuarioId,
                EstadoPedido = pedido.EstadoPedido,
                ProductoId = pedido.ProductoId
            };

        }

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Pedido> lista = _pedidoService.GetPedidosAsync().Result;
            List<PedidoModel> pedidos = new List<PedidoModel>();

            foreach (var item in lista)
            {
                pedidos.Add(Convertir(item));

            }

            return Ok(pedidos);
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Pedido pedido = await _pedidoService.GetById(id);
            PedidoModel pedidoModel = Convertir(pedido);

            return Ok(pedidoModel);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public IActionResult Post([FromBody] PedidoModel pedido)
        {
            Pedido entity = Convertir(pedido);
            _pedidoService.AddPedido(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<PedidoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] PedidoModel pedido)
        {
            Pedido entity = Convertir(pedido);
            _pedidoService.UpdatePedido(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<PedidoController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _pedidoService.DeletePedido(id);
        }
    }
}
