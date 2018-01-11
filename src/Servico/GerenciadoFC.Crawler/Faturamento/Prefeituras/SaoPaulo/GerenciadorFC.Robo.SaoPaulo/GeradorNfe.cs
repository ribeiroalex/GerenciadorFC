using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using OpenQA.Selenium.Firefox;

namespace GerenciadorFC.Robo.SaoPaulo
{
    public class GeradorNfe
    {
        public string Emissor(GerenciadorFC.Prestador.Prestador prestador, GerenciadorFC.Tomador.Tomador tomador)
        {
            string imageSrc = "";
            IWebDriver driver = new FirefoxDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Firefox.WebDriver\0.19.1\driver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var cnpj = driver.FindElement(By.Id("ctl00_body_tbCpfCnpj"));
            cnpj.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("ctl00_body_tbSenha"));
            senha.SendKeys(prestador.Senha);

            IWebElement html = driver.FindElement(By.TagName("html"));
            List<IWebElement> tabelaList = new List<IWebElement>(html.FindElements(By.TagName("table")));
            for (int i = 0; i < tabelaList.Count(); i++)
            {
                if (i == 2)
                {
                    IWebElement tabela = tabelaList[i];
                    List<IWebElement> tdList = new List<IWebElement>(tabela.FindElements(By.TagName("td")));
                    for (int i2 = 0; i2 < tdList.Count(); i2++)
                    {
                        if (i2 == 6)
                        {
                            IWebElement td = tdList[i2];
                            var img = td.FindElement(By.TagName("img"));
                            imageSrc = img.GetAttribute("src");
                        }
                    }
                }
            }
            //byte[] data;
            //using (WebClient client = new WebClient())
            //{
            //    data = client.DownloadData("view-source:" + imageSrc);
            //}
            //File.WriteAllBytes(@"C:\Users\fabio\Downloads\images\prefeitura.jpg", data);


            return "";
        }
    }
}
