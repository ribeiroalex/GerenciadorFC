using GerenciadorFC.Contextos.Cliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciatorFC.Clientes.Dominio.Entidades
{
    public class Empresa
    {
        public decimal EmpresaId { get; private set; }

        public string  RazaoSocial { get; private set; }

        public string  NomeFantasia { get; private set; }

        public string  InstricaoEstadual{ get; private set; }

        public DateTime DataInclusao{ get; private set; }

        public DateTime DataAtualizacao { get; private set; }

        public virtual List<Endereco> Enderecos{ get; private set; }

        public virtual  List<Telefone> Telefones{ get; private set; }

        public virtual ICollection<Funcionario> Funcionarios { get; private set; }

        public bool Status { get; private set; }
    }
}
