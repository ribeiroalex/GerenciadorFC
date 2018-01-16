using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contribuinte
{
    public class Contribuinte
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string Codigo { get; set; }
        public string Captcha { get; set; }
        public string ValorTributado { get; set; }
        public string Anexo { get; set; }
        public string Url { get; set; }
        public string CodigoAntiCaptcha { get; set; }
    }
}
