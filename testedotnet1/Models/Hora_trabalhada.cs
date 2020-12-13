using System;
using System.Collections.Generic;
using System.Text;

namespace testedotnet1.Models
{
    public class Hora_trabalhada
    {
        public int Id { get; set; }
        public DateTime Datainicio { get; set; }
        public DateTime Datafim { get; set; }
        public int desenvolvedorId { get; set; }
        public Desenvolvedor desenvolvedor { get; set; }
    }
}
