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
        private DesenvolvedoresRepository _DR;
        public DesenvolvedoresRepository DR
        {
            get
            {
                if (_DR == null)
                    _DR = new DesenvolvedoresRepository();
                return _DR;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDevAsync()
        {
            var dev = DR.GetDevs();
            if (dev == null)
                return NotFound();
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevAsync([FromBody] Desenvolvedor value)
        {
            var dev = new Desenvolvedor
            {
                Nome = "João",

            };
            dev = await DR.SalvarDevAsync(dev);
            if (dev == null)
                return BadRequest();
            return Ok(dev);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarDev([FromBody] Desenvolvedor value)
        {
            var dev = await DR.SalvarDevAsync(value);
            if (dev == null)
                return BadRequest();
            return Ok(dev);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirDev(/*[FromBody] Desenvolvedor value*/)
        {
            var dev = await DR.ExcluirDevAsync(1/*value.Id*/);
            if (dev == null)
                return BadRequest();
            return Ok(dev);
        }







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
        public async Task CriaHoras()
        {
            var devs = DR.GetDevs();
            Random rnd = new Random();

            for (int i = 0; i <= 1442; i++)
            {
                string iString = "2020-" + rnd.Next(1, 12).ToString("00") + "-" + rnd.Next(1, 30).ToString("00") + " " + rnd.Next(7, 12).ToString("00") + ":" + rnd.Next(0, 59).ToString("00") + ":" + rnd.Next(0, 24).ToString("00"); // "2005-05-05 22:12 PM";
                DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                var hora = new Hora_trabalhada();
                hora.Datainicio = oDate;
                hora.Datafim = oDate.AddHours(rnd.Next(5, 8)).AddMinutes(rnd.Next(10, 45));
                hora.desenvolvedor = devs[rnd.Next(1, devs.Count - 1)]; //devs.First(e => e.Id.Equals(rnd.Next(1, devs.Count-1)));

                //await Task.Delay((int)TimeSpan.FromSeconds(3).TotalMilliseconds);
                
                await HR.SalvarRegistroAsync(hora);
                //await Task.Delay((int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }
    }
}
