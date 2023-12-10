using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Controllers
{
    [Route("Api/[Controller]")]
    public class FacturaController : Controller
    {
        private readonly IFactura _factura;
        public FacturaController(IFactura factura)
        {
            _factura = factura;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Get()
        {
            return Ok(_factura.ObtenerFacturas());
        }
        [Route("{cod}")]
        public IActionResult Get(int cod)
        {
            var factRepo = _factura.ObtenerFacturaPorId(cod);
            if (factRepo == null)
            {
                var msgError = NotFound("Ocurrió un error, producto no existe");
                return msgError;
            }
            else
            {
                return Ok(factRepo);
            }
        }
        [Route("agregar")]
        public IActionResult addFactura(TbFactura factura)
        {
            _factura.add(factura);
            return CreatedAtAction(nameof(addFactura), factura);
        }
        // nuevo
        [Route("Edit/{cod}")]
        public IActionResult Update(TbFactura cod)
        {
            _factura.update(cod);
            return CreatedAtAction(nameof(Update), cod);
        }
        [Route("Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            _factura.delete(cod);
            return CreatedAtAction(nameof(Delete), cod);
        }
    }
}
