using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testedotnet1.Models;

namespace testedotnet1.Repository
{
    public class HorasRepository : BaseRepository
    {
        public Hora_trabalhada GetRegistro(int value)
        {
            try
            {
                return DataModel.Horas_Trabalhadas.First(e => e.Id == value);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public List<Hora_trabalhada> GetRegistrosDev(int value)
        {
            try
            {
                return DataModel.Horas_Trabalhadas.Where(e => e.desenvolvedor.Id == value).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<Hora_trabalhada> GetRegistrosMonth(DateTime value)
        {
            try
            {
                return DataModel.Horas_Trabalhadas.Where(e => e.Datainicio.Month == value.Month && e.Datainicio.Year == value.Year).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<Hora_trabalhada> GetRankingMonth(DateTime value)
        {
            try
            {
                var registros = GetRegistrosMonth(value);
                foreach (var registro in registros)
                {
                    registro.Datainicio.Subtract(registro.Datafim);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task SalvarRegistroAsync(Hora_trabalhada value)
        {
            DataModel.Entry(value).State = value.Id == 0 ?
                EntityState.Added : EntityState.Modified;
            await DataModel.SaveChangesAsync();
        }

        public async Task ExcluirRegistroAsync(int value)
        {
            var registro = GetRegistro(value);
            DataModel.Horas_Trabalhadas.Remove(registro);
            await DataModel.SaveChangesAsync();
        }
    }
}
