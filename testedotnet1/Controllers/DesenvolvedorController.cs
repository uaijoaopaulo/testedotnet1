using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testedotnet1.Models;
using testedotnet1.Repository;

namespace testedotnet1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesenvolvedorController : ControllerBase
    {
        private DesenvolvedoresRepository _HD;
        public DesenvolvedoresRepository HD
        {
            get
            {
                if (_HD == null)
                    _HD = new DesenvolvedoresRepository();
                return _HD;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDevAsync()
        {
            //var dev = new Desenvolvedor
            //{
            //    Nome = "João",

            //};
            //await HD.SalvarDevAsync(dev);

            var dev = HD.GetAll();
            if (dev == null)
                return NotFound();
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevAsync(/*[FromBody] Desenvolvedor value*/)
        {
            var dev = new Desenvolvedor
            {
                Nome = "João",

            };
            await HD.SalvarDevAsync(dev);
            //var dev = HD.GetAll();
            if (dev == null)
                return NotFound();
            return Ok(dev);
        }
    }
}
