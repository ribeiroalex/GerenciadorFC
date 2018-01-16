using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 

namespace GerenciadorFC.Robo.Receita.DAS
{
    public class ReceitaDAS
    {

        public void EmissorImpostos(GerenciadorFC.Contribuinte.Contribuinte contribuite)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(contribuite.Url);

            var cnpj = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCNPJ"));
            cnpj.SendKeys(contribuite.CNPJ);

            var cpf = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCPFResponsavel"));
            cpf.SendKeys(contribuite.CPF);

            var codigo = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCodigoAcesso"));
            codigo.SendKeys(contribuite.Codigo);

            var element = driver.FindElement(By.Id("captcha-img"));
            string imageSrc = element.GetAttribute("src");

            //var teste = AntiGate.GetBalance(contribuite.CodigoAntiCaptcha);

            //var captcha =  AntiGate.Recognize(imageSrc,null,0,0,false,false,false,false,false,contribuite.CodigoAntiCaptcha);


        } 
    }
}
