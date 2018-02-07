using GerenciadorFC.Contextos.Cliente.Dominio.Entidades;
using GerenciadorFC.Contextos.Cliente.Infra.Data.Mapeamentos;
using GerenciatorFC.Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace GerenciadorFC.Contextos.Cliente.Infra.Data.Contexto
{
    public class GerenciadoFCContext : DbContext
    {
        //public GerenciadoFCContext()
        //{
        //    Database. SetInitializer<GerenciadoFCContext>(new CreateDatabaseIfNotExists<GerenciadoFCContext>());
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=8056;database=GereniadorFCSite;user=root;password=ADMINgfc");
        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
        }
    }
}
