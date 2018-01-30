using GerenciadorFC.Crawler.Dominios.Prefeituras.Entidades;
using GerenciadorFC.Crawler.Prefeituras.Data.Mapeamentos;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Prefeituras.Data.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PrefeiturasContexto : DbContext
    {
        public PrefeiturasContexto() 
            : base("GerenciadorCrawler")
        {
            Database.SetInitializer<PrefeiturasContexto>(new CreateDatabaseIfNotExists<PrefeiturasContexto>());
        }

        public DbSet<Prestador> Prestadores { get; set; }

        public DbSet<Tomador> Tomadores { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new TomadorMap());
            modelBuilder.Configurations.Add(new PrestadorMap());

        }

    }
}
