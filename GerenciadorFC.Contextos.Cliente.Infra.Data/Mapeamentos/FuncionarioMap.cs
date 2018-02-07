using GerenciadorFC.Contextos.Cliente.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Contextos.Cliente.Infra.Data.Mapeamentos
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {

        }

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Telefones).WithOne(x => x.Funcionario).HasForeignKey(x => x.FuncionarioId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Enderecos).WithOne(x => x.Funcionario).HasForeignKey(x => x.FuncionarioId).OnDelete(DeleteBehavior.Cascade);


            builder.Property(x => x.Id).HasColumnName("FuncionarioId");

            builder.Property(x => x.EmpresaId).HasColumnName("EmpresaId").IsRequired();

            builder.Property(x => x.Tipo).HasColumnName("Tipo");
        }
    }
}
