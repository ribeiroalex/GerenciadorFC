using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GerenciadorFC.Robo.Guarulhos
{
    public class GeradorNfe
    {
        public bool Emissor(GerenciadorFC.Prestador.Prestador prestador, GerenciadorFC.Tomador.Tomador tomador)
        {
            bool emissor = false;
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.Id("ext-gen18")).Click();
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.ClassName("x-btn-text")).Click();
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.ClassName("imagem1")).Click();

            var inscr = driver.FindElement(By.Id("gwt-uid-3"));
            inscr.Click();
            System.Threading.Thread.Sleep(3000);
            var incricao = driver.FindElement(By.Id("ext-gen108"));
            incricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("ext-gen110"));
            senha.SendKeys(prestador.Senha);
            driver.FindElement(By.Id("ext-gen119")).Click();
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.Id("ext-gen327")).Click();
            driver.FindElement(By.Name("ext-gen473")).Click();
            var tipo = driver.FindElement(By.Id("ext-gen1112"));
            //var select_tipo = new SelectElement(tipo);
            if (prestador.Tipo == "PJ")
                //select_tipo.SelectByText("");
                driver.FindElement(By.Id("ext-gen1127")).Click();
            else
                driver.FindElement(By.Id("ext-gen1126")).Click();
                ///select_tipo.SelectByText("");
                // tipo.Click();
            System.Threading.Thread.Sleep(2000);
            var razao = driver.FindElement(By.Id("ext-gen413"));
            razao.SendKeys(prestador.RazaoSocial);
            var cnpj = driver.FindElement(By.Id("ext-gen453"));
            cnpj.SendKeys(prestador.Documento);
            var inscricao = driver.FindElement(By.Id("ext-gen457"));
            incricao.SendKeys(prestador.InscricaoMunicipal);
            var cep = driver.FindElement(By.Id("ext-gen459"));
            cep.SendKeys(prestador.CEP);
            var estado = driver.FindElement(By.Id("ext-gen485"));
            estado.SendKeys(prestador.Estado.ToUpper());
            var cidade = driver.FindElement(By.Id("ext-gen487"));
            cidade.SendKeys(prestador.Cidade.ToUpper());
            var logradouro = driver.FindElement(By.Id("ext-gen469"));
            logradouro.SendKeys(prestador.Endereco);
            var numero = driver.FindElement(By.Id("ext-gen471"));
            numero.SendKeys(prestador.Numero);
            var bairro = driver.FindElement(By.Id("ext-gen473"));
            bairro.SendKeys(prestador.Bairro);
            var complemento = driver.FindElement(By.Id("ext-gen475"));
            complemento.SendKeys(prestador.Complemento);
            var email = driver.FindElement(By.Id("ext-gen477"));
            email.SendKeys(prestador.Email);
            driver.FindElement(By.Id("ext-gen440")).Click();


            return emissor;
        }
    }
}
