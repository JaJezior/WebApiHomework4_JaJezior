using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WebApi.Model
{
    public class Context : DbContext
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=Election;Integrated Security=True;";
        //private static readonly string connectionString = "Data Source=.;Initial Catalog = ElectionContext;Integrated Security=True;";
        //DataSource określa adres serwera (po IP), jeśli kropka - lokalnie działająca maszyna 
        //Initial Catalog to nazwa bazy danych
        //Integrated Security=True; autoryzuje działania na bazie danych(daje programowi dostęp), albo odwrotnie

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Elector> Electors { get; set; }
        public DbSet<StateOfElection> StateOfElection { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
