using GerenciatorFC.Clientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Contextos.Cliente.Infra.Data.Mapeamentos
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
           
        }

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(x => x.EmpresaId);

            builder.Property(x => x.InstricaoEstadual)
                .HasColumnName("InstricaoEstadual")
                .IsRequired()
                .HasMaxLength(20);


            builder.HasMany(x => x.Funcionarios).WithOne(x => x.Empresa).HasForeignKey(x => x.EmpresaId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Telefones).WithOne(x => x.Empresa).HasForeignKey(x => x.EmpresaId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Enderecos).WithOne(x => x.Empresa).HasForeignKey(x => x.EmpresaId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.NomeFantasia)
                .HasColumnName("NomeFantasia")
                .IsRequired()
                .HasMaxLength(150);


            builder.Property(x => x.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
