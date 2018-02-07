using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Contextos.Nucleo.Infra.CrossCutting.ValueObjects
{
    public class NucleoTelefone
    {
        public string DD{ get; private set; }

        public string Numero { get; private set; }

        public NucleoTelefone(string dd, string numero)
        {
            DD = dd;
            Numero = numero;
        }

    }
}
