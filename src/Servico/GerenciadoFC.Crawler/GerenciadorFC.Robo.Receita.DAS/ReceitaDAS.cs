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
using System.Net.Mail;
using System.Net;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

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
            
            if (!IsElementPresent(By.Id("ctl00_ContentPlaceHolder_lblErro"),driver))
            {
                var pendencia = driver.FindElement(By.XPath("//*[@id='pFrameASN']/div[2]/a"));
                if (pendencia != null)
                    pendencia.Click();
                driver.FindElement(By.XPath("//li[contains(.,'Calcular valor devido')]")).Click();
                driver.FindElement(By.XPath("//*[@id='mItem11']/a/span")).Click();
                var dataApuracao = driver.FindElement(By.XPath("//*[@id='pFramePA']/div[2]/input"));
                dataApuracao.SendKeys(contribuite.mesApuracao + "/" + contribuite.anoApuracao);
                driver.FindElement(By.XPath("//*[@id='pFramePA']/div[3]/a[1]")).Click();
                try
                {
                    var errorMessage = driver.FindElement(By.XPath("//div[contains(@class, 'alert')]"));
                }
                catch (UnhandledAlertException f)
                {
                    try
                    {
                        var alert = driver.SwitchTo().Alert();
                        string alertText = alert.Text;
                        if (alertText.Contains("Já existe uma apuração transmitida para esse PA. Você deseja retificar a apuração anterior?") == true)
                        {
                            alert.Accept();
                        }
                        var alertSecon = driver.SwitchTo().Alert();
                        string alertTexSecon = alertSecon.Text;
                        if (alertTexSecon.Contains("Esta retificação não foi concluída. Deseja continuar esta operação?") == true)
                        {
                            alertSecon.Dismiss();
                            driver.FindElement(By.XPath("//li[contains(.,'Gerar DAS')]")).Click();
                            driver.FindElement(By.XPath("//*[@id='mItem17']/a/span")).Click();
                            var dataDAS = driver.FindElement(By.XPath("//*[@id='pFramePA']/div[2]/input"));
                            dataDAS.SendKeys(contribuite.mesApuracao + "/" + contribuite.anoApuracao);
                            driver.FindElement(By.XPath("//*[@id='pFramePA']/div[3]/a")).Click();
                            driver.FindElement(By.XPath("//*[@id='pFrameDas']/div[2]/a[3]")).Click();

                            //string currentHandle = driver.CurrentWindowHandle;
                            //ReadOnlyCollection<string> originalHandles = driver.WindowHandles;
                            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                            //string popupWindowHandle = wait.Until<string>((d) =>
                            //{
                            //    string foundHandle = null;

                            //    List<string> newHandles = driver.WindowHandles.Except(originalHandles).ToList();
                            //    if (newHandles.Count > 0)
                            //    {
                            //        foundHandle = newHandles[0];
                            //    }

                            //    return foundHandle;
                            //});

                            //var windows = driver.SwitchTo().Window(popupWindowHandle);

                            //var urlPDF = windows.Url.ToString();

                            string newTabHandle = driver.WindowHandles.Last();
                            var newTab = driver.SwitchTo().Window(newTabHandle);

                            /// var expectedNewTabTitle = "QA Automation Tools Tutorial";
                            ///Assert.AreEqual(expectedNewTabTitle, newTab.Title);

                            ///newTab.FindElement(By.XPath("//*[@id='icon']")).Click();


                            var url = newTab.Url.ToString();

                            string caminho = Path.Combine("E:\\Projeto\\GerenciadorFC\\Faturamento\\Prefeituras\\Aruja\\GerenciadorFC.Robo.Aruja\\", "NfePDF");
                            var fileName = Guid.NewGuid().ToString() + "DAS.pdf";
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(url, caminho + "\\" + fileName);
                            }

                            //cria uma mensagem
                            /// MailMessage mail = new MailMessage();

                            //define os endereços
                            //mail.From = new MailAddress("fabioesimoes@gmail.com");
                            //mail.To.Add("deniseviabrenha@gmail.com");

                            ////define o conteúdo
                            //mail.Subject = "Envio de DAS";
                            //mail.Body = "Teste de geração DAS automatico";
                            //Attachment attachment = new Attachment(caminho + "\\" + fileName);
                            //mail.Attachments.Add(attachment);


                            ////envia a mensagem
                            //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            //smtp.Send(mail);
                            ////var client = new SmtpClient("smtp.gmail.com", 587)
                            ////{
                            ////    Credentials = new NetworkCredential("fabioesimoes@gmail.com", "erivelto33"),
                            ////    EnableSsl = true
                            ////};
                            ////client.Send(, "myusername@gmail.com", "test", "testbody");

                        }

                    }
                    catch (NoAlertPresentException e)
                    {

                        driver.FindElement(By.XPath("//li[contains(.,'Gerar DAS')]")).Click();
                        driver.FindElement(By.XPath("//*[@id='mItem17']/a/span")).Click();
                        var dataDAS = driver.FindElement(By.XPath("//*[@id='pFramePA']/div[2]/input"));
                        dataDAS.SendKeys(contribuite.mesApuracao + "/" + contribuite.anoApuracao);
                        driver.FindElement(By.XPath("//*[@id='pFramePA']/div[3]/a")).Click();
                        driver.FindElement(By.XPath("//*[@id='pFrameDas']/div[2]/a[3]")).Click();

                        //string currentHandle = driver.CurrentWindowHandle;
                        //ReadOnlyCollection<string> originalHandles = driver.WindowHandles;
                        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
                        //string popupWindowHandle = wait.Until<string>((d) =>
                        //{
                        //    string foundHandle = null;

                        //    List<string> newHandles = driver.WindowHandles.Except(originalHandles).ToList();
                        //    if (newHandles.Count > 0)
                        //    {
                        //        foundHandle = newHandles[0];
                        //    }

                        //    return foundHandle;
                        //});

                        //var windows = driver.SwitchTo().Window(popupWindowHandle);

                        //var urlPDF = windows.Url.ToString();

                        string newTabHandle = driver.WindowHandles.Last();
                        var newTab = driver.SwitchTo().Window(newTabHandle);

                        /// var expectedNewTabTitle = "QA Automation Tools Tutorial";
                        ///Assert.AreEqual(expectedNewTabTitle, newTab.Title);

                        ///newTab.FindElement(By.XPath("//*[@id='icon']")).Click();


                        var url = newTab.Url.ToString();

                        string caminho = Path.Combine("E:\\Projeto\\GerenciadorFC\\Faturamento\\Prefeituras\\Aruja\\GerenciadorFC.Robo.Aruja\\", "NfePDF");
                        var fileName = Guid.NewGuid().ToString() + "DAS.pdf";
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(url, caminho + "\\" + fileName);
                        }

                        //cria uma mensagem
                        /// MailMessage mail = new MailMessage();

                        //define os endereços
                        //mail.From = new MailAddress("fabioesimoes@gmail.com");
                        //mail.To.Add("deniseviabrenha@gmail.com");

                        ////define o conteúdo
                        //mail.Subject = "Envio de DAS";
                        //mail.Body = "Teste de geração DAS automatico";
                        //Attachment attachment = new Attachment(caminho + "\\" + fileName);
                        //mail.Attachments.Add(attachment);


                        ////envia a mensagem
                        //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        //smtp.Send(mail);
                        ////var client = new SmtpClient("smtp.gmail.com", 587)
                        ////{
                        ////    Credentials = new NetworkCredential("fabioesimoes@gmail.com", "erivelto33"),
                        ////    EnableSsl = true
                        ////};
                        ////client.Send(, "myusername@gmail.com", "test", "testbody");
                    }
                }

            }
        }
        private bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
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
