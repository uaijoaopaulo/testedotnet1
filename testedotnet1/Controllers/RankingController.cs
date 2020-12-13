using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testedotnet1.Models;

namespace testedotnet1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankingController : ControllerBase
    {
        private RankingDesenvolvedores _RD;
        public RankingDesenvolvedores RD
        {
            get
            {
                if (_RD == null)
                    _RD = new RankingDesenvolvedores();
                return _RD;
            }
        }

        [HttpGet]
        public IActionResult GetRanking()
        {
            var Ranking = RD.GetRanking();
            if (Ranking == null)
                return NotFound();
            return Ok(Ranking);
        }

        [HttpGet("date")]
        public IActionResult GetRanking(DateTime date)
        {
            var Ranking = RD.GetRanking(date);
            if (Ranking == null)
                return NotFound();
            return Ok(Ranking);
        }
    }
}
