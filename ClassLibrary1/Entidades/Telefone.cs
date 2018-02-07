using GerenciadorFC.Contextos.Cliente.Dominio.Entidades;
using GerenciadorFC.Contextos.Nucleo.Infra.CrossCutting.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciatorFC.Clientes.Dominio.Entidades
{
    public class Telefone : NucleoTelefone
    {

        public Telefone(long telefoneId,string dd, string numero)
            :base(dd, numero)
        {
            TelefoneId = telefoneId;
        }

        public long TelefoneId{ get; set; }

        public bool Status { get; private set; }

        public Empresa Empresa{ get; private set; }

        public long EmpresaId { get; private set; }

        public Funcionario Funcionario { get; private set; }

        public long FuncionarioId { get; private set; }

    }
}
