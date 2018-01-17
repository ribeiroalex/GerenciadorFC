using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTeste
{
    public class ReceitaDAS
    {
        public static GerenciadorFC.Contribuinte.Contribuinte get_contribuite()
        {
            var contribuite = new GerenciadorFC.Contribuinte.Contribuinte();
            contribuite.CNPJ = "27308027000100";
            contribuite.CPF = "27952666878";
            contribuite.Codigo = "918126119242";
            contribuite.Url = "http://www8.receita.fazenda.gov.br/simplesnacional/controleacesso/autentica.aspx?id=6";
            contribuite.CodigoAntiCaptcha = "28f9d569983d49004ef89bf3735f919c";

            return contribuite;
        }
    }
}
