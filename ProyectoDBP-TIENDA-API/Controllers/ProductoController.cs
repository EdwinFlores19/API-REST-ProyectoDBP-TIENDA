using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Controllers
{
    [Route("Api/[Controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Get()
        {
            return Ok(_producto.ObtenerProductos());
        }
        [Route("{cod}")]
        public IActionResult Get(int cod)
        {
            var proRepo = _producto.ObtenerProductoPorId(cod);
            if (proRepo == null)
            {
                var msgError = NotFound("Ocurrió un error, producto no existe");
                return msgError;
            }
            else
            {
                return  Ok(proRepo);
            }
        }
        [Route("agregar")]
        public IActionResult addProducto(TbProducto producto)
        {
            try 
            { 
                _producto.add(producto);
                return CreatedAtAction(nameof(addProducto), producto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al agregar el producto: {ex.Message}");
            }
        }
        // nuevo
        [Route("editar/{cod}")]
        public IActionResult Update(TbProducto cod)
        {
            _producto.update(cod);
            return CreatedAtAction(nameof(Update), cod);
        }
        [Route("eliminar/{cod}")]
        public IActionResult Delete(int cod)
        {
            _producto.delete(cod);
            return CreatedAtAction(nameof(Delete), cod);
        }
    }
}
