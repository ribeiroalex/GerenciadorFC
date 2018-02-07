using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace GerenciadorFC.Contextos.Cliente.Infra.Data.Contexto
{
    public class GerenciadoFCContext : DbContext
    {
        public GerenciadoFCContext()
        {
            Database.SetInitializer<GerenciadoFCContext>(new CreateDatabaseIfNotExists<GerenciadoFCContext>());
        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
