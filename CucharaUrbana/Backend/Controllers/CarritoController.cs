using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {

        /// <summary>
        /// Convierte Carrito en ProducModel
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns></returns>
        CarritoModel Convertir(Carrito carrito)
        {
            return new CarritoModel
            {
                CarritoId = carrito.CarritoId,
                ProductoId = carrito.ProductoId,
                Cantidad = carrito.Cantidad,
                PrecioUnitario = carrito.PrecioUnitario,
            };
        }


        /// <summary>
        /// Convierte CarritoModel en Carrito
        /// </summary>
        /// <param name="carrito"></param>
        /// <returns></returns>
        Carrito Convertir(CarritoModel carrito)
        {
            return new Carrito
            {
                CarritoId = carrito.CarritoId,
                ProductoId = carrito.ProductoId,
                Cantidad = carrito.Cantidad,
                PrecioUnitario = carrito.PrecioUnitario,
            };
        }


        ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }


        // GET: api/<CarritoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Carrito> carritos = await _carritoService.GetCarritos();
            List<CarritoModel> carritoModels = new List<CarritoModel>();

            foreach (var item in carritos)
            {
                carritoModels.Add(this.Convertir(item));
            }


            return Ok(carritoModels);
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Carrito carrito = await _carritoService.GetById(id);
            return Ok(this.Convertir(carrito));
        }

        // POST api/<CarritoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarritoModel carritoModel)
        {
            Carrito carrito = this.Convertir(carritoModel);

            _carritoService.Add(carrito);



            return Ok(Convertir(carrito));
        }

        // PUT api/<CarritoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarritoModel carritoModel)
        {
            Carrito carrito = this.Convertir(carritoModel);

            _carritoService.Update(carrito);



            return Ok(Convertir(carrito));
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carritoService.Delete(id);

        }
    }
}
