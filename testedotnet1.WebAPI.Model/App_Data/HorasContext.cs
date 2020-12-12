using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace testedotnet1.WebAPI.Model.App_Data
{
    public class HorasContext : DbContext
    {
        public DbSet<Hora_trabalhada> Horas_Trabalhadas { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TESTEDOTNET1;Data Source=DESKTOP-11Q5IUF\MSSQLSERVER2");
        }
    }
}
