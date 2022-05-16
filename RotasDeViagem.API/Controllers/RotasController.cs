using Microsoft.AspNetCore.Mvc;
using RotasDeViagem.Application.DTOs;
using RotasDeViagem.Application.Interfaces;

namespace RotasDeViagem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        private readonly IVooService _vooService;

        public RotasController(IVooService vooService)
        {
            _vooService = vooService;
        }

        [HttpGet]
        [Route("todas-as-rotas")]
        public IActionResult GetRotas()
        {
            try
            {
                return Ok(_vooService.GetVoos());
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost()]
        [Route("escolher-rota")]
        public IActionResult GetMelhorRota(string origem, string destino)
        {
            try
            {
                return Ok(_vooService.GetMelhorRota(origem.ToUpper(), destino.ToUpper()));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("adicionar-nova-rota")]
        public IActionResult AddRota([FromBody] Voo2DTO voo)
        {
            try
            {
                _vooService.Create(voo);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("alterar-rota")]
        public IActionResult UpdateRota([FromBody] VooDTO voo)
        {
            try
            {
                _vooService.Update(voo);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("deleta-rota")]
        public IActionResult DeleteRota(int id)
        {
            try
            {
                _vooService.Remove(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}
