using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi92.Services;

namespace WebApi92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;
        public UsuariosController(IUsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuariosServices.GetUsuarios();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody]UsuariosResponse request)
        {
            var response = await _usuariosServices.CrearUsuario(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody]UsuariosResponse request)
        {
            var response = await _usuariosServices.ActualizarUsuario(id, request);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var response = await _usuariosServices.EliminarUsuario(id);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var response = await _usuariosServices.GetUsuarioById(id);
            return Ok(response);
        }
    }
}
