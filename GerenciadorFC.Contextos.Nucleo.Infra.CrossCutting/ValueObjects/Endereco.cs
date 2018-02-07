using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Contextos.Nucleo.Infra.CrossCutting.ValueObjects
{
    public class NucleoEndereco
    {

        public NucleoEndereco(string logradouro, string cidade, string estado, string complemento, string cep, string numero)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            Complemento = complemento;
            CEP = cep;
            Numero = numero;
        }


        public string Logradouro { get;private set; }

        public string Cidade { get;private set; }

        public string Estado { get;private set; }

        public string Complemento { get;private  set; }

        public string CEP { get;private set; }

        public string  Numero { get;private set; }
    }
}
