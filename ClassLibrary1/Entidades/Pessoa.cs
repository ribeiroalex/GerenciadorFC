using GerenciatorFC.Clientes.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciadorFC.Contextos.Cliente.Dominio.Entidades
{
    public class Pessoa
    {
        //chave declarada a partir do CPF/CNPJ
        public decimal Id { get; private set; }

        public DateTime DataInclusao { get; private set; }

        public bool Status { get; private set; }

        public DateTime DataAtualizacao { get; private set; }

        public string Nome { get; private set; }

        public virtual ICollection<Telefone> Telefones{get;private set;}

        public virtual ICollection<Endereco> Enderecos{ get;private set; }

        public Pessoa(decimal id, DateTime dataInclusao, string nome)
        {
           Id = id;
           DataInclusao = dataInclusao;
           Status = true;
            Nome = nome;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);

        }

        public void AdicionarTelefone(Telefone telefone)
        {
            Telefones.Add(telefone);
        }
    }
}