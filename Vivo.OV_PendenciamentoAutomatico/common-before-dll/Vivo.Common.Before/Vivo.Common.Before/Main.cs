using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Vivo.Common.Before
{

    public class Main
    {

        public static string GetResponse(string url, string token, string body)
        {
            return BusinessLogic.WebService.GetResponse(url,token,body);
        }

        public static HttpWebResponse GetResponse(string url, X509Certificate2 certificado, string body, Dictionary<string, string> headers = null)
        {
            return BusinessLogic.WebService.GetResponse(url, certificado, body, headers);
        }

        public static string GetResponse(string url, string body)
        {
            return BusinessLogic.WebService.GetResponse(url, body);
        }

        public static string GetResponse(string url,Dictionary<string,string> headers ,string body)
        {
            return BusinessLogic.WebService.GetResponse(url, headers, body);
        }

        public static string LoginB4(string url, string user)
        {
            return BusinessLogic.Selenium.LoginBefore(url, user);
        }

        public static string LoginB4(string url, string user, string canal = null)
        {
            return BusinessLogic.Selenium.LoginBefore(url, user, canal);
        }

        public static string AcessasrBKO()
        {
            return BusinessLogic.Selenium.AcessarBKO();
        }

        public static string ListarPendencia(string pendencia)
        {
            return BusinessLogic.Selenium.ListarPendencia(pendencia);
        }

        public static string PegarVenda(string canal)
        {
            return BusinessLogic.Rest.PegarVenda(canal);
        }

        public static string PegarVenda(string idVenda, string canal)
        {
            return BusinessLogic.Rest.PegarVenda(idVenda,canal);
        }

        public static string PendenciarVenda(string idVenda,string canal, string idPendenciaAPI,string observacao)
        {
            return BusinessLogic.Rest.PendenciarVenda(idVenda,canal,idPendenciaAPI,observacao);
        }

        public static string PendenciarVendaAgendamento(string idVenda,string canal, string idPendenciaAPI,string observacao,string data, string hora)
        {
            return BusinessLogic.Rest.PendenciarVendaAgendamento(idVenda,canal,idPendenciaAPI,observacao,data,hora);
        }

        public static string FinalizarVenda(string idVenda, string canal, string idPendenciaAPI,string observacao,JObject venda )
        {
            return BusinessLogic.Rest.FinalizarVenda(idVenda, canal, idPendenciaAPI, observacao, venda);
        }
    }
}
