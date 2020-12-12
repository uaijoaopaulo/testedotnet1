using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testedotnet1.Controllers
{
    public class RankingController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
