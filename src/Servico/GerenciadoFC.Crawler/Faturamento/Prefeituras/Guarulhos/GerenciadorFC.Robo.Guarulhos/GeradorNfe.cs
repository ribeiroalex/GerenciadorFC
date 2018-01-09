using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Chrome;



namespace GerenciadorFC.Robo.Guarulhos
{
    public class GeradorNfe
    {
        public async Task<bool> Emissor(GerenciadorFC.Prestador.Prestador prestador, GerenciadorFC.Tomador.Tomador tomador)
        {
            bool emissor = false;
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            IWebDriver driver = new ChromeDriver(@"C:\Users\Financeiro\Documents\Alex"); // new RemoteWebDriver(new  Uri( "http://localhost:9515"), DesiredCapabilities.Chrome());
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            await Task.Delay(5000);

            driver.FindElement(By.ClassName("x-btn-text")).Click();
            await Task.Delay(5000);
            driver.FindElement(By.ClassName("x-btn-text")).Click();
            await Task.Delay(5000);
            driver.FindElement(By.ClassName("imagem1")).Click();
            await Task.Delay(2000);
            var inscr = driver.FindElement(By.CssSelector("input[value='on']"));
            inscr.Click();
            await Task.Delay(4000);
            var findBy = By.CssSelector("input[class*='x-form-text x-form-field x-form-num-field']");
            var incricao = driver.FindElement(findBy);
            incricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.CssSelector("input[type='password']"));
            senha.SendKeys(prestador.Senha);
            driver.FindElements(By.ClassName("x-btn-text")).FirstOrDefault().Click();
            await Task.Delay(4000);
            var imagem = driver.FindElement(By.XPath("//img[@src='imgs/icon_nfse3.gif']"));

            if (imagem != null)
            {
                imagem.Click();
            }
            var cssSELECTOR = "input[class*=' x-form-text x-form-field x-combo-noedit ']";

            try
            {
                driver.FindElement(By.CssSelector(cssSELECTOR));
            }
            catch (Exception ex)
            {

            }
            var comboTipoPessoa = driver.FindElement(By.CssSelector(cssSELECTOR));
            await Task.Delay(2000);
            if (comboTipoPessoa != null)
            {
                //comboTipoPessoa.Click();
                //var select_tipo = new SelectElement(tipo);
                comboTipoPessoa.Click();
                if (prestador.Tipo == "PJ")
                {
                    //select_tipo.SelectByText("");

                    var pessoaJuridica = driver.FindElement(By.CssSelector(".x-combo-list-inner div[alt*='Pessoa Jurídica Direito Privado']"));

                    if (pessoaJuridica != null)
                    {
                        pessoaJuridica.Click();

                    }
                }
                else
                {
                    var pessoaFisica = driver.FindElement(By.CssSelector(".x-combo-list-inner div[alt*='Pessoa Física']"));


                    if (pessoaFisica != null)
                    {
                        pessoaFisica.Click();

                    }
                }
            }


            ///select_tipo.SelectByText("");
            // tipo.Click();
            await Task.Delay(4000);


            //PreencheFormulario
            string razaoSocialPath = string.Empty;
            razaoSocialPath = "//div[label/@text='Razão Social:']";

            var razao = driver.FindElements(By.XPath("//label[text()='Razão Social:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            razao.SendKeys(tomador.RazaoSocial);


            //var razao = driver.FindElement(By.CssSelector("div label[text=]"));
            //razao.SendKeys(tomador.RazaoSocial);

            var cnpj = driver.FindElements(By.XPath("//label[text()='CNPJ:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            cnpj.SendKeys(tomador.Documento);
            //var inscricao = driver.FindElements(By.XPath("//label[text()='Inscrição Municipal:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            //incricao.SendKeys(tomador.InscricaoMunicipal);

            var cep = driver.FindElements(By.XPath("//label[text()='CEP:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            cep.SendKeys(tomador.CEP);
            var estado = driver.FindElements(By.XPath("//label[text()='Estado:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            estado.Click();
            await Task.Delay(1000);

            driver.FindElement(By.XPath("//div[text()='" + tomador.Estado.ToUpper() + "']")).Click();
            await Task.Delay(4000);
            estado.Click();

            var cidade = driver.FindElements(By.XPath("//label[text()='Cidade:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            cidade.Click();
            await Task.Delay(4000);

            driver.FindElements(By.XPath("//div[text()='" + tomador.Cidade.ToUpper() + "']/ancestor::div[1]")).ElementAt(1).Click();
            await Task.Delay(1000);

            var logradouro = driver.FindElements(By.XPath("//label[text()='Logradouro:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            logradouro.SendKeys(tomador.Endereco);

            var numero = driver.FindElements(By.XPath("//label[text()='Número:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            numero.SendKeys(tomador.Numero);

            var bairro = driver.FindElements(By.XPath("//label[text()='Bairro:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            bairro.SendKeys(tomador.Bairro);

            var complemento = driver.FindElements(By.XPath("//label[text()='Complemento:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            complemento.SendKeys(tomador.Complemento);

            var email = driver.FindElements(By.XPath("//label[text()='E-mail:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            email.SendKeys(tomador.Email);


            driver.FindElement(By.XPath("//button[contains(text(),'Próximo')]")).Click();


            var atividade = driver.FindElements(By.XPath("//label[text()='Código do Serviço/Atividade:']/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input"));
            atividade.Click();
            await Task.Delay(4000);

             driver.FindElement(By.XPath("//div[text()='" + prestador.CodigoServico.ToUpper() + "']")).Click();
            await Task.Delay(1000);

            var valorServico = driver.FindElements(By.XPath("//label[contains(text(), 'Valor do serviço prestado:')]/ancestor::div[1]")).FirstOrDefault().FindElement(By.TagName("input")); 
            valorServico.SendKeys(prestador.Valor);



            var estado2 = driver.FindElements(By.XPath("//label[text()='Estado:']/ancestor::div[1]")).ElementAt(1).FindElement(By.TagName("input"));
            estado2.Click();
            await Task.Delay(1000);

            driver.FindElements(By.XPath("//div[text()='" + tomador.Estado.ToUpper() + "']")).ElementAt(2).Click(); ;
            await Task.Delay(4000);
            estado2.Click();

            var cidade2 = driver.FindElements(By.XPath("//label[text()='Cidade:']/ancestor::div[1]")).ElementAt(1).FindElement(By.TagName("input"));
            cidade2.Click();
            await Task.Delay(4000);

            var cidadeClick = driver.FindElements(By.XPath("//div[text()='" + tomador.Cidade.ToUpper() + "']/ancestor::div[1]")).Where(x => x.Displayed).FirstOrDefault();
            cidadeClick.Click();
            await Task.Delay(1000);



            driver.FindElement(By.XPath("//button[contains(text(),'Emitir')]")).Click();

            return emissor;
        }
    }
}
