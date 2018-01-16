using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;

namespace GerenciadorFC.Robo.SaoPaulo
{
    public class GeradorNfe
    {
        public async Task AcessarReceita()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Financeiro\Documents\Alex"); // new RemoteWebDriver(new  Uri( "http://localhost:9515"), DesiredCapabilities.Chrome());
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            driver.Navigate().GoToUrl("https://www8.receita.fazenda.gov.br/SimplesNacional/controleAcesso/Autentica.aspx?id=6");
            await Task.Delay(1000);

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
            var captchaText = ReadImage(filePath);

            var captchaInputText = driver.FindElement(By.Id("txtTexto_captcha_serpro_gov_br"));

            captchaInputText.SendKeys(captchaText);
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

        //public CookieContainer Login(GerenciadorFC.Prestador.Prestador prestador)
        //{
        //    string userName = prestador.Usuario;
        //    string password = prestador.Senha;
        //    string captcha = prestador.Captcha;

        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    string postData = "ctl00_body_tbCpfCnpj=" + userName + "&ctl00_body_tbSenha=" + password + "";
        //    byte[] postDataBytes = encoding.GetBytes(postData);

        //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(prestador.UlrLogin);

        //    httpWebRequest.Method = "POST";
        //    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        //    httpWebRequest.ContentLength = postDataBytes.Length;
        //    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.69 Safari/537.36";
        //    httpWebRequest.Proxy = null;
        //    httpWebRequest.AllowAutoRedirect = false;

        //    using (var stream = httpWebRequest.GetRequestStream())
        //    {
        //        stream.Write(postDataBytes, 0, postDataBytes.Length);
        //        stream.Close();
        //    }

        //    var cookieContainer = new CookieContainer();

        //    using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
        //    {
        //        using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        //        {
        //            foreach (Cookie cookie in httpWebResponse.Cookies)
        //            {
        //                cookieContainer.Add(cookie);
        //            }
        //        }
        //    }

        //    return cookieContainer;
        //}
    }
}
