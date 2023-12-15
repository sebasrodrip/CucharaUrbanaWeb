using Backend.Models;
using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        FacturaModel Convertir(Factura factura)
        {
            return new FacturaModel
            {
                FacturaId = factura.FacturaId,
                Detalle = factura.Detalle,
                CarritoId = factura.CarritoId,
                Subtotal = factura.Subtotal,
                TipoPagoId = factura.TipoPagoId,
                Fecha = factura.Fecha,

                /*Carrito = factura.Carrito,
                TipoPago = factura.TipoPago*/
            };

        }


        Factura Convertir(FacturaModel factura)
        {
            return new Factura
            {
                FacturaId = factura.FacturaId,
                Detalle = factura.Detalle,
                CarritoId = factura.CarritoId,
                Subtotal = factura.Subtotal,
                TipoPagoId = factura.TipoPagoId,
                Fecha = factura.Fecha,

                /*Carrito = factura.Carrito,
                TipoPago = factura.TipoPago*/
            };
        
        }


        IFacturaService _facturaService;


        public FacturaController(IFacturaService facturaService)
        {
                _facturaService = facturaService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            IEnumerable<Factura> lista =  await _facturaService.GetFactura(); 
            List<FacturaModel> facturas =  new List<FacturaModel>();

            foreach (var item in lista)
            {
                facturas.Add(Convertir(item));

            }

            return Ok(facturas);
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Factura factura = await _facturaService.GetById(id);
            return Ok(this.Convertir(factura));
        }

        // POST api/<FacturaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaModel facturamodel)
        {
            Factura factura = this.Convertir(facturamodel);
            _facturaService.Add(factura);
            return Ok(Convertir(factura));
        }

        // PUT api/<FacturaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FacturaModel facturaModel)
        {
            Factura factura = this.Convertir(facturaModel);

            _facturaService.Update(factura);

            return Ok(Convertir(factura));
        }


        // DELETE api/<FacturaController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _facturaService.Delete(id);

        }
    }
}
