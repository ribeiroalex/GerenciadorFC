
using System;


namespace GerenciadorFC.Contextos.Cliente.Dominio.Entidades
{
    public class Funcionario : Pessoa
    {
        public Funcionario(decimal id)
        :base(id, DateTime.Now)
        {
            
        }
    }
}