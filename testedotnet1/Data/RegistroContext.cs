using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testedotnet1.Models;

namespace testedotnet1.Data
{
    public class RegistroContext : DbContext
    {
        public DbSet<Hora_trabalhada> Horas_Trabalhadas { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TESTEDOTNET1;Data Source=DESKTOP-11Q5IUF\MSSQLSERVER2");
        }
    }
}
