using System;
using System.Collections.Generic;
using System.Text;
using GerenciadorFC.Contextos.Cliente.Dominio.Entidades;
using GerenciadorFC.Contextos.Nucleo.Infra.CrossCutting.ValueObjects;

namespace GerenciatorFC.Clientes.Dominio.Entidades
{
    public class Endereco : NucleoEndereco
    {
        public Endereco(long enderecoId,string logradouro, string cidade, string estado, string complemento, string cep, string numero)
            :base(logradouro, cidade, estado, complemento, cep, numero)
        {
            EnderecoId = enderecoId; 
        }

        public long EnderecoId{ get;private set; }

        public bool Status { get; private set; }

        public virtual Empresa Empresa { get; private set; }

        public long EmpresaId { get; private set; }

        public virtual Funcionario Funcionario { get;private set; }

        public long FuncionarioId { get; private set; }

    }
}
