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
        
        public List<RankingDesenvolvedores> GetRanking()
        {
            return GeraRanking(HR.GetRegistros());
        }
        public List<RankingDesenvolvedores> GetRanking(DateTime value)
        {
            return GeraRanking(HR.GetRegistrosMonth(value));
        }
        public List<RankingDesenvolvedores> GetListaDevs()
        {
            var ListaDev = new List<RankingDesenvolvedores>();
            foreach (var desenvolvedor in HD.GetDevs())
            {
                var DevRank = new RankingDesenvolvedores
                {
                    Id = desenvolvedor.Id,
                    Nome = desenvolvedor.Nome,
                    HorasTrabalhadas = 0
                };
                ListaDev.Add(DevRank);
            }
            return ListaDev;
        }
        public List<RankingDesenvolvedores> GeraRanking(List<Hora_trabalhada> ListaHoras)
        {
            var ListaDev = GetListaDevs();

            try
            {
                foreach (var registro in ListaHoras)
                {
                    var horas = registro.Datainicio.Subtract(registro.Datafim);
                    ListaDev[registro.desenvolvedor.Id].HorasTrabalhadas += horas.TotalHours;
                }
                return ListaDev.Take(5).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        
    }
}
