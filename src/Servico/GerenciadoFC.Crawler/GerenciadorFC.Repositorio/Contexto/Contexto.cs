using GerenciadorFC.Contribuinte;
using System.Data.Entity;


namespace GerenciadorFC.Repositorio.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto()
             : base("Contexto")
        {

        }
        public DbSet<Contribuinte.Contribuinte> Contribuinte { get; set; }
    }
}
