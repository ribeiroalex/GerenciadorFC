using GerenciadorFC.Crawler.Dominios.Prefeituras.Entidades;
using GerenciadorFC.Crawler.Prefeituras.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Prefeituras.Data.Repositorios
{
    public class TomadorRepository : RepositoryBase<Tomador>
    {
        public TomadorRepository(PrefeiturasContexto contexto)
            :base(contexto)
        {

        }
    }
}
