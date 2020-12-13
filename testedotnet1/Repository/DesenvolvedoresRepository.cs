using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testedotnet1.Models;
using Microsoft.AspNetCore.Mvc;

namespace testedotnet1.Repository
{
    public class DesenvolvedoresRepository : BaseRepository
    {
        public Desenvolvedor GetDev(int value)
        {
            try
            {
                return DataModel.Desenvolvedores.First(e => e.Id == value);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        public List<Desenvolvedor> GetDevs()
        {
            try
            {
                return DataModel.Desenvolvedores.ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<Desenvolvedor> SalvarDevAsync(Desenvolvedor value)
        {
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

        public async Task<int?> ExcluirDevAsync(int value)
        {
            try
            {
                var dev = GetDev(value);
                DataModel.Desenvolvedores.Remove(dev);
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
