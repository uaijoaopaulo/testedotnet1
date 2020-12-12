using System;
using System.Collections.Generic;
using System.Linq;
using testedotnet1.Repository;

namespace testedotnet1.Models
{
    public class RankingDesenvolvedores 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double HorasTrabalhadas { get; set; }

        private HorasRepository _HR;
        private HorasRepository HR
        {
            get
            {
                if (_HR == null)
                    _HR = new HorasRepository();
                return _HR;
            }
        }

        private DesenvolvedoresRepository _HD;
        private DesenvolvedoresRepository HD
        {
            get
            {
                if (_HD == null)
                    _HD = new DesenvolvedoresRepository();
                return _HD;
            }
        }

        public List<RankingDesenvolvedores> GetRankingMonth(DateTime value)
        {
            var ListaDev = new List<RankingDesenvolvedores>();
            foreach (var desenvolvedor in HD.GetAll())
            {
                var DevRank = new RankingDesenvolvedores
                {
                    Id = desenvolvedor.Id,
                    Nome = desenvolvedor.Nome,
                    HorasTrabalhadas = 0
                };
                ListaDev.Add(DevRank);
            }

            try
            {
                var registros = HR.GetRegistrosMonth(value);
                foreach (var registro in registros)
                {
                    var horas = registro.Datainicio.Subtract(registro.Datafim);
                    ListaDev.First(e => e.Id == registro.desenvolvedor.Id).HorasTrabalhadas += horas.TotalHours;
                }
                return ListaDev;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


    }
}
