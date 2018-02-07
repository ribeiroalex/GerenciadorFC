using GerenciadorFC.Contextos.Cliente.Infra.Data.Contexto;
using GerenciadorFC.Contextos.Nucleo.Infra.Data;
using GerenciatorFC.Clientes.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorFC.Contextos.Cliente.Infra.Data
{
    public class EmpresaRepository : RepositoryBase<Empresa, GerenciadoFCContext>
    {
        public EmpresaRepository(GerenciadoFCContext contexto)
            :base(contexto)
        {

        }
    }
}
