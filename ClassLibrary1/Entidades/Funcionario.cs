
using GerenciatorFC.Clientes.Dominio.Entidades;
using System;


namespace GerenciadorFC.Contextos.Cliente.Dominio.Entidades
{
    public class Funcionario : Pessoa
    {
        public Funcionario(Int16 tipo, decimal id,long empresaId, string nome)
        :base(id, DateTime.Now, nome)
        {
            EmpresaId = empresaId;
            Tipo = tipo;
        }

        public long EmpresaId { get; private set; }

        public virtual Empresa Empresa { get; private set; }

        public Int16 Tipo { get; private set; }
    }
}