using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorFC.Prestador;
using GerenciadorFC.Tomador;



namespace AppTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            var prestador = new Prestador();
            var tomador = new Tomador();
            //var guarulhosNfe = new GerenciadorFC.Robo.Guarulhos.GeradorNfe();
            //var arujaNfe = new GerenciadorFC.Robo.Aruja.GeradorNfe();
            //var arujaCancel = new GerenciadorFC.Robo.Aruja.CancelaNfe();
            //var arujaConsulta = new GerenciadorFC.Robo.Aruja.ConsultaNFe();
            var itaquaNfe = new GerenciadorFC.Robo.Itaquaquecetuba.ConsultaNfe();
            //tomador = AppTeste.Guarulhos.get_Tomador();
            //prestador = AppTeste.Guarulhos.get_Prestador();

            //tomador = AppTeste.Aruja.get_Tomador();
            //prestador = AppTeste.Aruja.get_Prestador();

            tomador = AppTeste.Itaquaquecetuba.get_Tomador();
            prestador = AppTeste.Itaquaquecetuba.get_Prestador();

            //Task.Run(() => guarulhosNfe.Emissor(prestador, tomador)).Wait();
            //string nfe =  arujaNfe.Emissor(prestador, tomador);

            ///arujaConsulta.Consulta("40", prestador);
            ///
            ///itaquaNfe.Emissor(prestador, tomador);
            itaquaNfe.Consulta("739", prestador);



        }
    }
}
