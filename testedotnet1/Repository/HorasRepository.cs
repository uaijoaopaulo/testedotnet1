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
        public List<Hora_trabalhada> GetRegistros()
        {
            try
            {
                return DataModel.Horas_Trabalhadas.ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
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
                return DataModel.Horas_Trabalhadas.Where(e => e.Datainicio.Month == value.Month 
                && e.Datainicio.Year == value.Year).ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<Hora_trabalhada> SalvarRegistroAsync(Hora_trabalhada value)
        {
            var HorasConflitantes = DataModel.Horas_Trabalhadas.Where
                (e => e.desenvolvedorId.Equals(value.desenvolvedorId) 
            && e.Datainicio.Year.Equals(value.Datainicio.Year)
            && e.Datainicio.Month.Equals(value.Datainicio.Month) 
            && e.Datainicio.Day.Equals(value.Datainicio.Day)).ToList();
            if(HorasConflitantes.Count != 0)
                foreach (var Hora in HorasConflitantes)
                {
                    if (Hora.Datainicio.Hour <= value.Datainicio.Hour
                    || Hora.Datafim.Hour >= value.Datafim.Hour)
                    return null;
                }
            try
            {
                DataModel.Entry(value).State = value.Id == 0 ?
                    EntityState.Added : EntityState.Modified;
                await DataModel.SaveChangesAsync();

                return value;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }

        public async Task<int?> ExcluirRegistroAsync(int value)
        {
            try
            {
                var registro = GetRegistro(value);
                DataModel.Horas_Trabalhadas.Remove(registro);
                await DataModel.SaveChangesAsync();
                return value;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }
    }
}
