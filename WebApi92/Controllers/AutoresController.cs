using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi92.Services;

namespace WebApi92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;

        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            var response = await _autorServices.GetAutores();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(Autor autor)
        {
            var response = await _autorServices.CreateAutor(autor);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutor(Autor autor, int id)
        {
            var response = await _autorServices.UpdateAutor(autor, id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var response = await _autorServices.DeleteAutor(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutorById(int id)
        {
            var response = await _autorServices.GetAutorById(id);
            return Ok(response);
        }
    }
}
