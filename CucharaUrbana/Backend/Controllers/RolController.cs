using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        public IRolService _rolService;

        private Rol Convertir(RolModel rol)
        {
            return new Rol
            {
                RolId = rol.RolId,
                NombreRol = rol.NombreRol
            };
        
        }


        private RolModel Convertir(Rol rol)
        {
            return new RolModel
            {
                RolId = rol.RolId,
                NombreRol = rol.NombreRol
            };

        }

        public RolController(IRolService rolService)
        {
                _rolService = rolService;
        }

        // GET: api/<RolController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Rol> lista =  _rolService.GetRolsAsync().Result; 
            List<RolModel> rols =  new List<RolModel>();

            foreach (var item in lista)
            {
                rols.Add(Convertir(item));

            }

            return Ok(rols);
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Rol rol = _rolService.GetById(id);
            RolModel rolModel = Convertir(rol);

            return Ok(rolModel);
        }

        // POST api/<RolController>
        [HttpPost]
        public IActionResult Post([FromBody] RolModel rol)
        {
            Rol entity = Convertir(rol);
            _rolService.AddRol(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<RolController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] RolModel rol)
        {
            Rol entity = Convertir(rol);
            _rolService.UpdateRol(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Rol rol = new Rol
            {
                RolId = id
            };

            _rolService.DeteleRol(rol);

            return Ok();
        }
    }
}
