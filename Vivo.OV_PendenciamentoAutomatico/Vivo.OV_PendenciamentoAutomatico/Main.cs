using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Direct.Shared;
using System.Globalization;

namespace Vivo.OV_PendenciamentoAutomatico
{
    [DirectSealed]
    [DirectDom("Pendenciamento Automático DLL")]
    [ParameterType(true)]
    public class Main
    {
        [DirectDom("Login_Before")]
        [DirectDomMethod("Login_Before {canal}")]
        [MethodDescriptionAttribute("Login na aplicação no canal escolhido")]
        public static string Login_Before(string canal)
        {
            return BL.BeforeScreen.Login(canal);
        }

        

        [DirectDom("CloseChrome")]
        [DirectDomMethod("CloseChrome")]
        [MethodDescriptionAttribute("fecha o browser")]
        public static string CloseChrome()
        {
            return BL.BeforeScreen.CloseChrome();
        }

        [DirectDom("AcessarBKO_Before")]
        [DirectDomMethod("AcessarBKO_Before")]
        [MethodDescriptionAttribute("Acessar a listagem do Backoffice")]
        public static string AcessarBKO()
        {
            return Vivo.Common.Before.Main.AcessasrBKO();
        }

        [DirectDom("FiltrarPendencia_Before")]
        [DirectDomMethod("FiltrarPendencia_Before {Pendencia}")]
        [MethodDescriptionAttribute("Selecionar filtro da pendencia")]
        public static string ListarPendencia(string pendencia)
        {
            return Vivo.Common.Before.Main.ListarPendencia(pendencia);
        }

        [DirectDom("AcessarHomePage_Before")]
        [DirectDomMethod("AcessarHomePage_Before")]
        [MethodDescriptionAttribute("Clica no botão home")]
        public static string AccessHomePage()
        {
            return BL.BeforeScreen.AccessHomePage();
        }

        [DirectDom("SearchVendaPendenciaVendedor_Before")]
        [DirectDomMethod("SearchVendaPendenciaVendedor_Before")]
        [MethodDescriptionAttribute("Procura venda pendencia vendedor acima de 24h")]
        public static string SearchVendaPendVendedor()
        {
            return BL.BeforeScreen.SearchVendaPendVendedor24();
        }

        [DirectDom("SearchVendaPendNaoLoc24_Before")]
        [DirectDomMethod("SearchVendaPendNaoLoc24_Before")]
        [MethodDescriptionAttribute("Procura venda pendencia não localizado acima de 24h")]
        public static string SearchVendaPendNaoLoc24()
        {
            return BL.BeforeScreen.SearchVendaPendNaoLoc24();
        }

        [DirectDom("PegarVenda Request")]
        [DirectDomMethod("PegarVenda {idVenda} {canal}")]
        [MethodDescriptionAttribute("Post request with certificate authenticate returning json string")]
        public static string PegarVenda(string idVenda, string canal)
        {
            return BL.BeforeAPI.PegarVenda(idVenda, canal);
        }

        [DirectDom("PendenciarVenda Request")]
        [DirectDomMethod("PendenciarVenda {idVenda} {canal} {idPendencia}")]
        [MethodDescriptionAttribute("Post request with certificate authenticate returning json string")]
        public static string PendenciarVenda(string idVenda, string canal,string idPendencia)
        {
            return BL.BeforeAPI.PendenciarVenda(idVenda,canal, idPendencia);
        }

        [DirectDom("FinalizarVenda Request")]
        [DirectDomMethod("FinalizarVenda {idVenda} {canal} {idPendencia}")]
        [MethodDescriptionAttribute("Post request with certificate authenticate returning json string")]
        public static string FinalizarVenda(string idVenda, string canal, string idPendencia)
        {
            return BL.BeforeAPI.FinalizarVenda(idVenda,canal, idPendencia);
        } 
    }
}
