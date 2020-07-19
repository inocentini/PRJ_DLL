using System;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Vivo.Common.Before.BusinessLogic
{
    public static class WebService
    {

        internal static string certificateNice = Environment.CurrentDirectory.ToString() + @"\certificate.pfx";
        /// <summary>
        /// Este método retorna um response request para API, recebendo uma URL, onde será feito o request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpWebResponse GetResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            X509Certificate2 certificate1 = new X509Certificate2(certificateNice);
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection collection = new X509Certificate2Collection();
            collection.Add(certificate1);
            request.ClientCertificates = collection;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Close();

            return response;
        }


        public static string GetResponse(string url, string token, string body)
        {
            //URL qual vai ser chamada
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //tokem de produção Vivo Sun
            request.Headers.Add("SUN-API-Token", token);
            //Configuração da chamada POST GET PUT etc
            request.Headers.Add("AllowAutoRedirect", "true");
            request.ContentType = "application/json";
            request.Method = "POST";

            //Carregamento do certificado 
            X509Certificate2 certificate1 = new X509Certificate2(certificateNice);
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection collection = new X509Certificate2Collection
            {
                certificate1
            };
            request.ClientCertificates = collection;

            // Montagem do Body 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            var requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);

            //capturando a resposta da chamada
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string result;
            using (var dataStream = response.GetResponseStream())
            {
                var sr = new System.IO.StreamReader(dataStream);
                result = sr.ReadToEnd();
                
     
            }

            response.Close();
            requestStream.Close();
            //retorana a mensagem de response como JSON
            return JObject.Parse(result).ToString();
        }

        public static string GetResponse(string url, string body)
        {
            //URL qual vai ser chamada
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //Configuração da chamada POST GET PUT etc
            request.Headers.Add("AllowAutoRedirect", "true");
            request.ContentType = "application/json";
            request.Method = "POST";

            //Carregamento do certificado 
            X509Certificate2 certificate1 = new X509Certificate2(certificateNice);
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection collection = new X509Certificate2Collection
            {
                certificate1
            };
            request.ClientCertificates = collection;

            // Montagem do Body 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            var requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);

            //capturando a resposta da chamada
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string result;
            using (var dataStream = response.GetResponseStream())
            {
                var sr = new System.IO.StreamReader(dataStream);
                result = sr.ReadToEnd();


            }

            response.Close();
            requestStream.Close();
            //retorana a mensagem de response como JSON
            return JObject.Parse(result).ToString();
        }

        public static string GetResponse(string url, Dictionary<string, string> headers, string body)
        {
            //URL qual vai ser chamada
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //headers
            foreach(var index in headers)
            {
                request.Headers.Add(index.Key, index.Value);
            }
            //Configuração da chamada POST GET PUT etc
            request.Headers.Add("AllowAutoRedirect", "true");
            request.ContentType = "application/json";
            request.Method = "POST";

           
            //Carregamento do certificado 
            X509Certificate2 certificate1 = new X509Certificate2(certificateNice);
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection collection = new X509Certificate2Collection
            {
                certificate1
            };
            request.ClientCertificates = collection;

            // Montagem do Body 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            var requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);

            //capturando a resposta da chamada
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string result;
            using (var dataStream = response.GetResponseStream())
            {
                var sr = new System.IO.StreamReader(dataStream);
                result = sr.ReadToEnd();
            }

            response.Close();
            requestStream.Close();
            //retorana a mensagem de response como JSON
            return JObject.Parse(result).ToString();
        }

        public static HttpWebResponse GetResponse(string url, X509Certificate2 certificado, string body, Dictionary<string, string> headers = null)
        {
            headers = headers ?? new Dictionary<string, string>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //headers
            foreach (var index in headers)
            {
                request.Headers.Add(index.Key, index.Value);
            }
            //Configuração da chamada POST GET PUT etc
            request.Headers.Add("AllowAutoRedirect", "true");
            request.ContentType = "application/json";
            request.Method = "POST";


            //Carregamento do certificado 
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection collection = new X509Certificate2Collection
            {
                certificado
            };
            request.ClientCertificates = collection;

            // Montagem do Body 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            var requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);

            //capturando a resposta da chamada
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Close();
            requestStream.Close();
            //retorana a mensagem de response como JSON
            return response;
        }



    }
}
