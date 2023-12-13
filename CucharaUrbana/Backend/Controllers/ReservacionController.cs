using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {

        public IReservacionService _reservacionService;

        private Reservacion Convertir(ReservacionModel reservacion)
        {
            return new Reservacion
            {
                ReservacionId = reservacion.ReservacionId,
                FechaReservacion = reservacion.FechaReservacion,
                MesaReservacion = reservacion.MesaReservacion,
                HoraReservacion = reservacion.HoraReservacion,
                DetalleReservacion = reservacion.DetalleReservacion,

            };

        }


        private ReservacionModel Convertir(Reservacion reservacion)
        {
            return new ReservacionModel
            {
                ReservacionId = reservacion.ReservacionId,
                FechaReservacion = reservacion.FechaReservacion,
                MesaReservacion = reservacion.MesaReservacion,
                HoraReservacion = reservacion.HoraReservacion,
                DetalleReservacion = reservacion.DetalleReservacion,

            };

        }

        public ReservacionController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;
        }

        // GET: api/<ReservacionController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Reservacion> lista = _reservacionService.GetReservacionAsync().Result;
            List<ReservacionModel> reservaciones = new List<ReservacionModel>();

            foreach (var item in lista)
            {
                reservaciones.Add(Convertir(item));

            }

            return Ok(reservaciones);
        }

        // GET api/<ReservacionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Reservacion reservacion = _reservacionService.GetById(id);
            ReservacionModel reservacionModel = Convertir(reservacion);

            return Ok(reservacionModel);
        }

        // POST api/<ReservacionController>
        [HttpPost]
        public IActionResult Post([FromBody] ReservacionModel reservacion)
        {
            Reservacion entity = Convertir(reservacion);
            _reservacionService.AddReservacion(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<ReservacionController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ReservacionModel reservacion)
        {
            Reservacion entity = Convertir(reservacion);
            _reservacionService.UpdateReservacion(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<ReservacionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Reservacion reservacion = new Reservacion
            {
                ReservacionId = id
            };

            _reservacionService.DeleteReservacion(reservacion);

            return Ok();
        }
    }
}
