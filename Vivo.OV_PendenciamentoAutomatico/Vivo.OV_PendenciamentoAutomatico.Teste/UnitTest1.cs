using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Internal;
using Vivo.OV_PendenciamentoAutomatico.Model;

namespace Vivo.OV_PendenciamentoAutomatico.Teste
{
    [TestClass]
    public class UnitTest1
    {
        string result;
        [TestMethod]
        public void TestMethod1()
        {
            Main.Login_Before("VENDAS");
            Main.AcessarBKO();
            Main.ListarPendencia("Não Loc.");
            Main.SearchVendaPendNaoLoc24();
        }
    }
}
