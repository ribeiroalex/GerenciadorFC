<<<<<<< HEAD
﻿using OpenQA.Selenium;
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
=======
﻿using System;
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
>>>>>>> cdbbfc28abfa3f0ef58d9d683ce9d0d18ab9d8a1

namespace GerenciadorFC.Robo.SaoPaulo
{
    public class GeradorNfe
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> cdbbfc28abfa3f0ef58d9d683ce9d0d18ab9d8a1
    }
}
