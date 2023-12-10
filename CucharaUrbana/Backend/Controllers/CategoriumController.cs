using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriumController : ControllerBase
    {

        public ICategoriumService _categoriumService;
        ILogger<CategoriumController> _logger;

        private Categorium Convertir(CategoriumModel categorium)
        {
            return new Categorium
            {
                CategoriaId = categorium.CategoriaId,
               Nombre = categorium.Nombre
            };
        
        }


        private CategoriumModel Convertir(Categorium categorium)
        {
            return new CategoriumModel
            {
                CategoriaId = categorium.CategoriaId,
                Nombre = categorium.Nombre
            };

        }

        public CategoriumController(ICategoriumService categoriumService, ILogger<CategoriumController> logger)
        {
                _categoriumService = categoriumService;
            _logger = logger;
        }

        // GET: api/<CategoriumController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogError("***********PRUEBA ERROR **************");
            IEnumerable<Categorium> lista =  _categoriumService.GetCategoriesAsync().Result; 
            List<CategoriumModel> categories =  new List<CategoriumModel>();

            foreach (var item in lista)
            {
                categories.Add(Convertir(item));

            }

            return Ok(categories);
        }

        // GET api/<CategoriumController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("***********PRUEBA INFROMACION  **************");
            Categorium categorium = _categoriumService.GetById(id);
            CategoriumModel categoriumModel = Convertir(categorium);

            return Ok(categoriumModel);
        }

        // POST api/<CategoriumController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoriumModel categorium)
        {
            Categorium entity = Convertir(categorium);
            _categoriumService.AddCategorium(entity);
            return Ok(Convertir(entity));

        }

        // PUT api/<CategoriumController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] CategoriumModel categorium)
        {
            Categorium entity = Convertir(categorium);
            _categoriumService.UpdateCategorium(entity);
            return Ok(Convertir(entity));
        }



        // DELETE api/<CategoriumController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Categorium categorium = new Categorium
            {
                CategoriaId = id
            };

            _categoriumService.DeleteCategorium(categorium);

            return Ok();
        }
    }
}
