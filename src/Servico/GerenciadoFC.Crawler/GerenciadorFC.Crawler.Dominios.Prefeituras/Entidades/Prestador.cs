using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Dominios.Prefeituras.Entidades
{
    public class Prestador
    {
        public Prestador()
        {

        }

        public Prestador(Guid id )
        {
            PretadorId = id;
        }

        public Guid PretadorId { get; private set;}

        public string Documento { get; private set;}
        public string RazaoSocial { get; private set;}
        public string InscricaoMunicipal { get; private set;}
        public string Fantasia { get; private set;}
        public string Endereco { get; private set;}
        public string Numero { get; private set;}
        public string Bairro { get; private set;}
        public string CEP { get; private set;}
        public string Complemento { get; private set;}
        public string Cidade { get; private set;}
        public string UF { get; private set;}
        public string Estado { get; private set;}
        public string Email { get; private set;}
        public string CodigoServico { get; private set;}
        public string Discriminacao { get; private set;}
        public string Valor { get; private set;}
        public string Usuario { get; private set;}
        public string Senha { get; private set;}
        public string Captcha { get; private set;}
        public string UlrLogin { get; private set;}
        public string Tipo { get; private set;}
    }
}
