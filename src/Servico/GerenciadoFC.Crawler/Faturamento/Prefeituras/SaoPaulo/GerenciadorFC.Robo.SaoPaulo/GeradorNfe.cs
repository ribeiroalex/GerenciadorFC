using System.IO;
using System.Net;
using System.Text;

namespace GerenciadorFC.Robo.SaoPaulo
{
    public class GeradorNfe
    {
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
