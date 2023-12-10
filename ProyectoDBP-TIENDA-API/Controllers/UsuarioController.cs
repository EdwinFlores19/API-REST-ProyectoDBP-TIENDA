using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA_API.Models;
using ProyectoDBP_TIENDA_API.Services.Interface;

namespace ProyectoDBP_TIENDA_API.Controllers
{
    [Route("Api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Get()
        {
            return Ok(_usuario.ObtenerUsuarios());
        }
        [Route("{cod}")]
        public IActionResult Get(string cod)
        {
            var usuRepo = _usuario.ObtenerUsuarioPorId(cod);
            if (usuRepo == null)
            {
                var msgError = NotFound("Ocurrió un error, producto no existe");
                return msgError;
            }
            else
            {
                return Ok(usuRepo);
            }
        }
        [Route("agregar")]
        public IActionResult addUsuario(TbUsuario usuario)
        {
            _usuario.add(usuario);
            return CreatedAtAction(nameof(addUsuario), usuario);
        }
        // nuevo
        [Route("editar/{cod}")]
        public IActionResult Update(TbUsuario cod)
        {
            _usuario.update(cod);
            return CreatedAtAction(nameof(Update), cod);
        }
        [Route("eliminar/{cod}")]
        public IActionResult Delete(string cod)
        {
            _usuario.delete(cod);
            return CreatedAtAction(nameof(Delete), cod);
        }
    }
}
