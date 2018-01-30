using GerenciadorFC.Crawler.Dominios.Prefeituras.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Prefeituras.Data.Mapeamentos
{
    public class TomadorMap : EntityTypeConfiguration<Tomador>
    {
        public TomadorMap()
        {
            ToTable("Tomador");

            HasKey(x => x.TomadorId);

            Property(x => x.TomadorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Documento).HasColumnName("Documento").IsRequired();
            Property(x => x.RazaoSocial).HasColumnName("RazaoSocial").IsRequired();
            Property(x => x.InscricaoMunicipal).HasColumnName("InscricaoMunicipal").IsRequired();
            Property(x => x.Fantasia).HasColumnName("Fantasia").IsRequired();
            Property(x => x.Endereco).HasColumnName("Endereco").IsRequired();
            Property(x => x.Cidade).HasColumnName("Cidade").IsRequired();
            Property(x => x.UF).HasColumnName("UF").IsRequired();
            Property(x => x.Email).HasColumnName("Email").IsRequired();
            Property(x => x.TipoPessoa).HasColumnName("TipoPessoa").IsRequired();
            Property(x => x.Numero).HasColumnName("Numero").IsRequired();
            Property(x => x.Bairro).HasColumnName("Bairro").IsRequired();
            Property(x => x.CEP).HasColumnName("CEP").IsRequired();
            Property(x => x.Complemento).HasColumnName("Complemento").IsRequired();
        }
    }
}
