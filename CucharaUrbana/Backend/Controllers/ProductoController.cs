using Backend.Models;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]

    [Authorize]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        /// <summary>
        /// Convierte Producto en ProducModel
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        ProductoModel Convertir(Producto producto)
        {
            return new ProductoModel
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                CategoriaId = producto.CategoriaId

            };
        }


        /// <summary>
        /// Convierte ProductoModel en Producto
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        Producto Convertir(ProductoModel producto)
        {
            return new Producto
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                CategoriaId = producto.CategoriaId

            };
        }


        IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;  
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            IEnumerable<Producto> productos =await _productoService.GetProductos();
            List<ProductoModel> productoModels = new List<ProductoModel>();

            foreach (var item in productos)
            {
                productoModels.Add(this.Convertir(item));
            }


            return Ok(productoModels);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Producto producto =await _productoService.GetById(id);
            return Ok(this.Convertir(producto));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoModel productoModel)
        {
            Producto producto = this.Convertir(productoModel);

            _productoService.Add(producto);



            return Ok(Convertir(producto));
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductoModel productoModel)
        {
            Producto producto = this.Convertir(productoModel);

            _productoService.Update(producto);



            return Ok(Convertir(producto));
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _productoService.Delete(id);

        }
    }
}
