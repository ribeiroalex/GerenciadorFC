using System;

namespace GerenciadorFC.Contextos.Cliente.Dominio.Entidades
{
    public class Pessoa
    {
        //chave declarada a partir do CPF/CNPJ
        public decimal Id{ get;private set; }

        public DateTime DataInclusao {get;private set;}

        public bool Ativo {get;private set;} 

        public Pessoa(decimal id, DateTime dataInclusao)
        {
           Id = id;
           DataInclusao = dataInclusao;
           Ativo = true;
        }
    }
}