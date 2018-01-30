using GerenciadorFC.Crawler.Aplicacao.Interfaces;
using GerenciadorFC.Crawler.Aplicacao.ViewModel.Prefeituras;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Aplicacao.Servicos
{
    public class Itaquaquicetuba : INotaFiscal
    {
        public bool Cancelar(string numeroNotaFiscal, PrestadorViewModel prestador)
        {
            bool cancela = false;

            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\Documents\ChromeDriver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var inscricao = driver.FindElement(By.Id("usuario"));
            inscricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("senha"));
            senha.SendKeys(prestador.Senha);

            driver.FindElement(By.Id("closebuttons1btOk")).Click();
            driver.FindElement(By.Id("td11")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var frame = driver.FindElement(By.TagName("iframe"));
            ///driver.SwitchTo().DefaultContent();
            ///
            ///await Task.Delay(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var _frame = driver.SwitchTo().Frame(frame);


            var frame2 = _frame.SwitchTo().Frame(_frame.FindElement(By.Id("inferior")));

            var pesquisa = _frame.FindElement(By.Id("_vlrCampo"));
            pesquisa.SendKeys(numeroNotaFiscal);
            _frame.FindElement(By.XPath("//*[@id='_CBoTrOk']/td[2]")).Click();
            driver.SwitchTo().DefaultContent();
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.Name("gridCheck")).Click();

            if (driver.PageSource.ToString().Contains(">Normal</span>"))
            {
                driver.FindElement(By.Id("img1")).Click();
                List<IWebElement> lisframe = new List<IWebElement>(driver.FindElements(By.TagName("iframe")));
                var frameTeste = lisframe[1];
                var frameC = frameTeste;
                var _frameC = driver.SwitchTo().Frame(frameC);
                var frame2C = _frameC.SwitchTo().Frame(_frameC.FindElement(By.Id("inferior")));
                var textArea = _frameC.FindElement(By.Id("textarea1"));
                textArea.SendKeys("Cancelada");
                _frameC.FindElement(By.Id("_CBobtOk")).Click();
                cancela = true;
                driver.Quit();
            }


            return cancela;
        }

        public string ConsultaPorNumero(string nfe, PrestadorViewModel prestador)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\Documents\ChromeDriver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var inscricao = driver.FindElement(By.Id("usuario"));
            inscricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("senha"));
            senha.SendKeys(prestador.Senha);

            driver.FindElement(By.Id("closebuttons1btOk")).Click();
            driver.FindElement(By.Id("td11")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var frame = driver.FindElement(By.TagName("iframe"));
            ///driver.SwitchTo().DefaultContent();
            ///
            ///await Task.Delay(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var _frame = driver.SwitchTo().Frame(frame);


            var frame2 = _frame.SwitchTo().Frame(_frame.FindElement(By.Id("inferior")));

            var pesquisa = _frame.FindElement(By.Id("_vlrCampo"));
            pesquisa.SendKeys(nfe);
            _frame.FindElement(By.XPath("//*[@id='_CBoTrOk']/td[2]")).Click();
            driver.SwitchTo().DefaultContent();
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.Name("gridCheck")).Click();
            string currentHandle = driver.CurrentWindowHandle;
            ReadOnlyCollection<string> originalHandles = driver.WindowHandles;

            driver.FindElement(By.XPath("//*[@id='imagebutton1Imagem']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            string popupWindowHandle = wait.Until<string>((d) =>
            {
                string foundHandle = null;

                List<string> newHandles = driver.WindowHandles.Except(originalHandles).ToList();
                if (newHandles.Count > 0)
                {
                    foundHandle = newHandles[0];
                }

                return foundHandle;
            });

            var windows = driver.SwitchTo().Window(popupWindowHandle);

            var urlPDF = windows.Url.ToString();

            string fileNane = prestador.Documento.Replace("/", "").Replace(".", "").Replace("-", "") + "_" + nfe + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".pdf";
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string caminho = Path.Combine("E:\\Projeto\\GerenciadorFC\\GerenciadorFC.Robo.Itaquaquecetuba\\", "NfePDF");
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(urlPDF, caminho + "\\" + fileNane);
            }
            windows.Quit();
            driver.Quit();

            return fileNane;
        }

        public string Emitir(PrestadorViewModel prestador, TomadorViewModel tomador)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var inscricao = driver.FindElement(By.Id("usuario"));
            inscricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("senha"));
            senha.SendKeys(prestador.Senha);

            driver.FindElement(By.XPath("//*[@id='closebuttons1btOk']/table/tbody/tr/td[2]")).Click();
            driver.FindElement(By.Id("img1")).Click();
            var documento = driver.FindElement(By.Id("qycnpjcpf"));
            documento.SendKeys(tomador.Documento);
            var nome = driver.FindElement(By.Id("qynome"));
            nome.SendKeys(tomador.RazaoSocial);
            if (tomador.TipoPessoa == "PF")
            {
                var checkPF = driver.FindElement(By.Id("qytppessoaradioFisica"));
                checkPF.Click();
            }
            var cep = driver.FindElement(By.Id("input8"));
            cep.SendKeys(tomador.CEP);

            var endereco = driver.FindElement(By.Id("input6"));
            endereco.SendKeys(tomador.Endereco + " " + tomador.Numero);

            var bairro = driver.FindElement(By.Id("input4"));
            bairro.SendKeys(tomador.Bairro);

            var cidade = driver.FindElement(By.Id("input2"));
            cidade.SendKeys(tomador.Cidade);

            var uf = driver.FindElement(By.Id("input3"));
            uf.SendKeys(tomador.UF);

            var email = driver.FindElement(By.Id("input10"));
            email.SendKeys(tomador.Email);

            var codigo = driver.FindElement(By.Id("icodigo"));
            codigo.SendKeys("0");

            var discriminacao = driver.FindElement(By.Id("qynfitensdescritem"));
            discriminacao.SendKeys(prestador.Discriminacao);

            var qtde = driver.FindElement(By.Id("qynfitensqtd"));
            qtde.SendKeys("1");

            var valor_uni = driver.FindElement(By.Id("qynfitensvlrunitario"));
            valor_uni.Clear();
            valor_uni.SendKeys(prestador.Valor.Replace(",", "."));

            var valor = driver.FindElement(By.Id("qynfitensvlrtotal"));
            valor.Clear();
            valor.SendKeys(prestador.Valor.Replace(",", "."));

            var imposto = driver.FindElement(By.Id("qytotalimpostoaprox"));
            imposto.SendKeys("0");

            var aliquota = driver.FindElement(By.Id("qyaliquotaimpostoaprox"));
            aliquota.SendKeys("0");

            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("imagebutton1Imagem")).Click();

            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("imagebutton4Imagem")).Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement tabela = driver.FindElement(By.Id("table7"));
            var nfe = "";
            List<IWebElement> listTD = new List<IWebElement>(tabela.FindElements(By.TagName("td")));
            foreach (var item in listTD)
            {
                if (item.Text.Contains("A nota fiscal número"))
                {
                    nfe = item.Text.ToString();
                    nfe = Regex.Replace(nfe, @"[^\d]", "");
                }
            }

            System.Threading.Thread.Sleep(2000);
            driver.Quit();

            return nfe;
        }
    }
}
