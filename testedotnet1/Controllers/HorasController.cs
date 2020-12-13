using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testedotnet1.Models;
using testedotnet1.Repository;

namespace testedotnet1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorasController : ControllerBase
    {
        private HorasRepository _HR;
        public HorasRepository HR
        {
            get
            {
                if (_HR == null)
                    _HR = new HorasRepository();
                return _HR;
            }
        }

        [HttpGet]
        public IActionResult HorasRegistradas()
        {
            var hora = HR.GetRegistros();
            if (hora == null)
                return NotFound();
            return Ok(hora);
        }

        [HttpGet("{id}")]
        public IActionResult HoraRegistrada(int id)
        {
            var hora = HR.GetRegistro(id);
            if (hora == null)
                return NotFound();
            return Ok(hora);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHoraAsync([FromBody] Hora_trabalhada value)
        {
            if (ModelState.IsValid)
            {
                var hora = await HR.SalvarRegistroAsync(value);
                if (hora == null)
                    return BadRequest();
                return Ok(hora);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarHora([FromBody] Hora_trabalhada value)
        {
            if (ModelState.IsValid)
            {
                var hora = await HR.SalvarRegistroAsync(value);
                if (hora == null)
                    return BadRequest();
                return Ok(hora);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirHora([FromBody] Hora_trabalhada value)
        {
            if (ModelState.IsValid)
            {
                var hora = await HR.ExcluirRegistroAsync(value.Id);
                if (hora == null)
                    return NoContent();
                return Ok(hora);
            }
            return BadRequest();
        }
    }
}
