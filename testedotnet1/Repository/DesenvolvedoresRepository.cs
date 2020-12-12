using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testedotnet1.Models;

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
        public List<Desenvolvedor> GetAll()
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

        public async Task SalvarDevAsync(Desenvolvedor value)
        {
            DataModel.Entry(value).State = value.Id == 0 ?
                EntityState.Added : EntityState.Modified;
            await DataModel.SaveChangesAsync();
        }

        public async Task ExcluirDevAsync(int value)
        {
            var dev = GetDev(value);
            DataModel.Desenvolvedores.Remove(dev);
            await DataModel.SaveChangesAsync();
        }
    }
}
