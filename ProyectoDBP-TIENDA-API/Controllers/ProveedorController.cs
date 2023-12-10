using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Controllers
{
    [Route("Api/[Controller]")]
    public class ProveedorController : Controller
    {
        private readonly IProveedor _proveedor;
        public ProveedorController(IProveedor proveedor)
        {
            _proveedor = proveedor;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Get()
        {
            return Ok(_proveedor.ObtenerProveedores());
        }
        [Route("{cod}")]
        public IActionResult Get(int cod)
        {
            var proRepo = _proveedor.ObtenerProveedorPorId(cod);
            if (proRepo == null)
            {
                var msgError = NotFound("Ocurrió un error, producto no existe");
                return msgError;
            }
            else
            {
                return Ok(proRepo);
            }
        }
        [Route("agregar")]
        public IActionResult addProveedor(TbProveedor proveedor)
        {
            _proveedor.add(proveedor);
            return CreatedAtAction(nameof(addProveedor), proveedor);
        }
        // nuevo
        [Route("Edit/{cod}")]
        public IActionResult Update(TbProveedor cod)
        {
            _proveedor.update(cod);
            return CreatedAtAction(nameof(Update), cod);
        }
        [Route("Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            _proveedor.delete(cod);
            return CreatedAtAction(nameof(Delete), cod);
        }
    }
}
