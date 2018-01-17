using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;
using System.IO;

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

            var captchaObject = driver.FindElement(By.Id("captcha-img"));
            var captchaSRC = captchaObject.GetAttribute("src");
            var directory = AppDomain.CurrentDomain.BaseDirectory;

            string[] imgsrcList = captchaSRC.Split(',');
            var filePath = string.Format("{0}\\captcha.png", directory);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            using (var binatyStream = new BinaryWriter(stream))
            {
                byte[] base64Array = Convert.FromBase64String(imgsrcList[1]);

                binatyStream.Write(base64Array);
            }

            var captchaText = ReadImage(filePath, contribuite.CodigoAntiCaptcha);

            var captchaInputText = driver.FindElement(By.Id("txtTexto_captcha_serpro_gov_br"));

            captchaInputText.SendKeys(captchaText);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder_btContinuar")).Click();

            var pendencia = driver.FindElement(By.XPath("//*[@id='pFrameASN']/div[2]/a"));
            if (pendencia != null)
                pendencia.Click();
            driver.FindElement(By.Id("//li[contains(., 'Calcular valor devido')]")).Click();
        }
        public string ReadImage(string filepath, string apiKey)
        {
            string captchaText = string.Empty;

            var api = new ImageToText
            {
                ClientKey = apiKey,
                FilePath = filepath
            };

            if (!api.CreateTask())
            {
                Console.WriteLine("API v2 send failed. " + api.ErrorMessage ?? "", DebugHelper.Type.Error);
            }
            else if (!api.WaitForResult())
            {
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            }
            else
            {
                captchaText = api.GetTaskSolution();

                DebugHelper.Out("Result: " + captchaText, DebugHelper.Type.Success);
            }

            return captchaText;
        }
    }
}
