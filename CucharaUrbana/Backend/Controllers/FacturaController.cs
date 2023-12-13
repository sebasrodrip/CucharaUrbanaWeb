using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        public IFacturaService _facturaService;

        private Factura Convertir(FacturaModel factura)
        {
            return new Factura
            {
                FacturaId = factura.FacturaId,
                TipoPagoId = factura.TipoPagoId
            };
        
        }


        private FacturaModel Convertir(Factura factura)
        {
            return new FacturaModel
            {
                FacturaId = factura.FacturaId,
                TipoPagoId = factura.TipoPagoId
            };

        }

        public FacturaController(IFacturaService facturaService)
        {
                _facturaService = facturaService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Factura> lista =  _facturaService.GetFacturaAsync().Result; 
            List<FacturaModel> facturas =  new List<FacturaModel>();

            foreach (var item in lista)
            {
                facturas.Add(Convertir(item));

            }

            return Ok(facturas);
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Factura factura = _facturaService.GetById(id);
            FacturaModel facturaModel = Convertir(factura);

            return Ok(facturaModel);
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] FacturaModel factura)
        {
            Factura entity = Convertir(factura);
            _facturaService.AddFactura(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<FacturaController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] FacturaModel factura)
        {
            Factura entity = Convertir(factura);
            _facturaService.UpdateFactura(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Factura factura = new Factura
            {
                FacturaId = id
            };

            _facturaService.DeleteFactura(factura);

            return Ok();
        }
    }
}
