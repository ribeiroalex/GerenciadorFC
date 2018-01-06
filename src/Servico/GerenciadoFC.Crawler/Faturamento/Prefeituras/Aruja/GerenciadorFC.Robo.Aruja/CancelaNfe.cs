using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace GerenciadorFC.Robo.Aruja
{
    public class CancelaNfe
    {
        public bool Cancelar(string nfe, GerenciadorFC.Prestador.Prestador prestador)
        {
            bool cancela = false;

            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var inscricao = driver.FindElement(By.Id("usuario"));
            inscricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("senha"));
            senha.SendKeys(prestador.Senha);

            driver.FindElement(By.Id("closebuttons1btOk")).Click();
            driver.FindElement(By.Id("td11")).Click();

            System.Threading.Thread.Sleep(5000);
            var pesquisa = driver.FindElement(By.Id("_vlrCampo"));
            pesquisa.SendKeys(nfe);






            return cancela;
        }
    }
}
