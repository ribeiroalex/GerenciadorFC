using GerenciadorFC.Crawler.Aplicacao.ViewModel.Prefeituras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Aplicacao.Interfaces
{
    public interface INotaFiscal
    {
        string Emitir(PrestadorViewModel prestador, TomadorViewModel tomador);

        bool Cancelar(string numeroNotaFiscal, PrestadorViewModel prestador);

        string ConsultaPorNumero(string nfe, PrestadorViewModel prestador);
    }
}
