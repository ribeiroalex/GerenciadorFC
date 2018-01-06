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
            var guarulhosNfe = new GerenciadorFC.Robo.Guarulhos.GeradorNfe();
            var arujaNfe = new GerenciadorFC.Robo.Aruja.GeradorNfe();
            var arujaCancel = new GerenciadorFC.Robo.Aruja.CancelaNfe();

            //tomador = AppTeste.Guarulhos.get_Tomador();
            //prestador = AppTeste.Guarulhos.get_Prestador();

            tomador = AppTeste.Aruja.get_Tomador();
            prestador = AppTeste.Aruja.get_Prestador();

            //guarulhosNfe.Emissor(prestador, tomador);
            //string nfe =  arujaNfe.Emissor(prestador, tomador);

            arujaCancel.Cancelar("39", prestador);
                       

        }
    }
}
