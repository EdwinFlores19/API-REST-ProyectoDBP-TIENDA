using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Controllers
{
    [Route("Api/[Controller]")]
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Get()
        {
            return Ok(_admin.ObtenerAdmins());
        }
        [Route("{cod}")]
        public IActionResult Get(int cod)
        {
            var admRepo = _admin.ObtenerAdminPorId(cod);
            if (admRepo == null)
            {
                var msgError = NotFound("Ocurrió un error, producto no existe");
                return msgError;
            }
            else
            {
                return Ok(admRepo);
            }
        }
        [Route("agregar")]
        public IActionResult addAdmin(TbAdmin admin)
        {
            _admin.add(admin);
            return CreatedAtAction(nameof(addAdmin), admin);
        }
        // nuevo
        [Route("Edit/{cod}")]
        public IActionResult Update(TbAdmin cod)
        {
            _admin.update(cod);
            return CreatedAtAction(nameof(Update), cod);
        }
        [Route("Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            _admin.delete(cod);
            return CreatedAtAction(nameof(Delete), cod);
        }
    }
}
