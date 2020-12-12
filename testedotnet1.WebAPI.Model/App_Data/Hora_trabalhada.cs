using System;
using System.Collections.Generic;
using System.Text;

namespace testedotnet1.WebAPI.Model.App_Data
{
    public class Hora_trabalhada
    {
        public int Id { get; set; }
        public DateTime Datainicio { get; set; }
        public DateTime Datafim { get; set; }
        public Desenvolvedor desenvolvedor { get; set; }
    }
}
