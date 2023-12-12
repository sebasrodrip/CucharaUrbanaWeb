using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CategoriumController : ControllerBase
    {

        /// <summary>
        /// Convierte Categorium en ProducModel
        /// </summary>
        /// <param name="categorium"></param>
        /// <returns></returns>
        CategoriumModel Convertir(Categorium categorium)
        {
            return new CategoriumModel
            {
                CategoriaId = categorium.CategoriaId,
                Nombre = categorium.Nombre,
            };
        }


        /// <summary>
        /// Convierte CategoriumModel en Categorium
        /// </summary>
        /// <param name="categorium"></param>
        /// <returns></returns>
        Categorium Convertir(CategoriumModel categorium)
        {
            return new Categorium
            {
                CategoriaId = categorium.CategoriaId,
                Nombre = categorium.Nombre,
            };
        }


        ICategoriumService _categoriumService;

        public CategoriumController(ICategoriumService categoriumService)
        {
            _categoriumService = categoriumService;
        }


        // GET: api/<CategoriumController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Categorium> categoriums = await _categoriumService.GetCategoriesAsync();
            List<CategoriumModel> categoriumModels = new List<CategoriumModel>();

            foreach (var item in categoriums)
            {
                categoriumModels.Add(this.Convertir(item));
            }


            return Ok(categoriumModels);
        }

        // GET api/<CategoriumController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Categorium categorium = await _categoriumService.GetById(id);
            return Ok(this.Convertir(categorium));
        }

        // POST api/<CategoriumController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriumModel categoriumModel)
        {
            Categorium categorium = this.Convertir(categoriumModel);

            _categoriumService.AddCategorium(categorium);



            return Ok(Convertir(categorium));
        }

        // PUT api/<CategoriumController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoriumModel categoriumModel)
        {
            Categorium categorium = this.Convertir(categoriumModel);

            _categoriumService.UpdateCategorium(categorium);



            return Ok(Convertir(categorium));
        }

        // DELETE api/<CategoriumController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _categoriumService.DeleteCategorium(id);

        }
    }
}
