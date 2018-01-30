using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Dominios.Prefeituras.Entidades
{
    public class Tomador
    {
        public Tomador()
        {

        }

        public Tomador(Guid Id)
        {
            TomadorId = Id;
        }

        public Guid TomadorId { get;private set; }
        public string Documento { get;private set; }
        public string RazaoSocial { get;private set; }
        public string InscricaoMunicipal { get;private set; }
        public string Fantasia { get;private set; }
        public string Endereco { get;private set; }
        public string Cidade { get;private set; }
        public string UF { get;private set; }
        public string Email { get;private set; }
        public string TipoPessoa { get;private set; }
        public string Numero { get;private set; }
        public string Bairro { get;private set; }
        public string CEP { get;private set; }
        public string Complemento { get;private set; }
    }
}
