using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {


        ReservacionModel Convertir(Reservacion reservacion)
        {
            return new ReservacionModel
            {
                ReservacionId = reservacion.ReservacionId,
                UsuarioId = reservacion.UsuarioId,
                FechaReservacion = reservacion.FechaReservacion,
                MesaReservacion = reservacion.MesaReservacion,
                HoraReservacion = reservacion.HoraReservacion,
                DetalleReservacion = reservacion.DetalleReservacion

            };
        }



        Reservacion Convertir(ReservacionModel reservacion)
        {
            return new Reservacion
            {
                ReservacionId = reservacion.ReservacionId,
                UsuarioId = reservacion.UsuarioId,
                FechaReservacion = reservacion.FechaReservacion,
                MesaReservacion = reservacion.MesaReservacion,
                HoraReservacion = reservacion.HoraReservacion,
                DetalleReservacion = reservacion.DetalleReservacion

            };
        }


        IReservacionService _reservacionService;

        public ReservacionController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;  
        }


        [HttpGet]
        public async Task <IActionResult> Get()
        {
            IEnumerable<Reservacion> reservacion =await _reservacionService.GetReservacion();
            List<ReservacionModel> reservacionModels = new List<ReservacionModel>();

            foreach (var item in reservacion)
            {
                reservacionModels.Add(this.Convertir(item));
            }


            return Ok(reservacionModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Reservacion reservacion = await _reservacionService.GetById(id);
            return Ok(this.Convertir(reservacion));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservacionModel reservacionModel)
        {
            Reservacion reservacion = this.Convertir(reservacionModel);

            _reservacionService.Add(reservacion);



            return Ok(Convertir(reservacion));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ReservacionModel reservacionModel)
        {
            Reservacion reservacion = this.Convertir(reservacionModel);

            _reservacionService.Update(reservacion);



            return Ok(Convertir(reservacion));
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _reservacionService.Delete(id);

        }
    }
}
