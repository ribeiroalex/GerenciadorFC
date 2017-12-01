using System.Data.Entity;

namespace GerenciadorFC.Contextos.Cliente.Infra.Data
{
    public class Pessoa
    {
        //chave declarada a partir do CPF/CNPJ
        public decimal Id{ get;private set; }

        public DateTime DataInclusao {get;pirvate set;}

        public bool Ativo {get;private set;} 

        public Pessoa(decimal id, DateTime dataInclusao)
        {
           Id = id;
           DataInclusao = dataInclusao;
           Ativo = true;
        }
    }
}