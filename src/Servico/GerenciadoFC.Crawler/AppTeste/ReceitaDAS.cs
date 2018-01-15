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
            contribuite.CNPJ = "12991814000114";
            contribuite.CPF = "37420365806";
            contribuite.Codigo = "773589306028";
            contribuite.Url = "http://www8.receita.fazenda.gov.br/simplesnacional/controleacesso/autentica.aspx?id=6";
            contribuite.CodigoAntiCaptcha = "a7d065c09cd1371735d7a4060cb310bb";

            return contribuite;
        }
    }
}
