namespace GerenciadorFC.Crawler.Prefeituras.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GerenciadorFC.Crawler.Prefeituras.Data.Contexto.PrefeiturasContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GerenciadorFC.Crawler.Prefeituras.Data.Contexto.PrefeiturasContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
