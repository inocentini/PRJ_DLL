using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DriverSelenium = Vivo.Common.Fwk.BusinessProcess.Selenium;
using System.Globalization;

namespace Vivo.Common.Before.BusinessLogic
{
    public static class Selenium
    {
        public static string LoginBefore(string url, string user, string canal = null)
        {
            string retorno = "fail";
            try
            {
                string urlB4 = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter(url)));
                string userB4 = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter(user)));
                string pwd = Fwk.Dll.Util.GetPassword(user);

                DriverSelenium.InitializeChromeDriverHeadless(Environment.CurrentDirectory,debugmode:true,proxy:true);
                DriverSelenium.Driver.Manage().Window.Maximize();
                DriverSelenium.GoToUrl(urlB4);
                if (DriverSelenium.WaitToLoad(By.Id("can_id"),10))
                {
                    IWebElement selectField = DriverSelenium.FindElement(By.Id("can_id"));
                    var selectElement = new SelectElement(selectField);
                    selectElement.SelectByText(UppercaseFirst(canal));
                }
                if (DriverSelenium.WaitToLoad(By.Id("us_re"), 10))
                {
                    IWebElement inputUser = DriverSelenium.FindElement(By.Id("us_re"));
                    inputUser.SendKeys(userB4);
                }
                IWebElement inputPass = DriverSelenium.FindElement(By.Id("us_senha"));
                inputPass.SendKeys(pwd);
                IWebElement btnEntrar = DriverSelenium.FindElement(By.CssSelector("input[type='submit']"));
                btnEntrar.Click();
                if (DriverSelenium.WaitToLoad(By.Id("capaAtalhos")))
                {
                    retorno = "success";
                }
            }
            catch(Exception err)
            {
                retorno = retorno + err;
            }

            return retorno;
        }


        public static string AcessarBKO()
        {
            string retorno = "fail";
            try
            {
                var btnBko = DriverSelenium.FindElement(By.CssSelector("i[class='fa fa-phone-square']"));
                btnBko.Click();
                if(DriverSelenium.WaitToLoad(By.CssSelector("body > div:nth-child(5) > div.module-container > div > div > div > div:nth-child(2) > div.status-filter-list"))){
                    retorno = "success";
                }
                else
                {
                    retorno = "Erro ao acessar o BKO";
                }
            }
            catch(Exception err)
            {
                retorno = retorno + err;
            }
            return retorno;
        }


        public static string ListarPendencia(string pendencia)
        {
            Dictionary<string, string> deParaPend = new Dictionary<string, string>();
            deParaPend.Add("Vendedor", "P. VENDEDOR");
            deParaPend.Add("Não Loc.", "P. NÃO LOC.");
            deParaPend.Add("Sistêmica", "P. SISTEMCIA");
            deParaPend.Add("RPA", "RPA");
            int count = 0;
            string retorno = "fail";
            try
            {
                //Clica na seta para abrir as opções de Pendencias
                var btnSeta = DriverSelenium.FindElement(By.CssSelector("div.svg-icon.subfilter-arrow"));
                btnSeta.Click();
                if (DriverSelenium.WaitToLoad(By.CssSelector("div.subfilters"))) 
                { 
                    IReadOnlyCollection<IWebElement> checkBoxSpanList = DriverSelenium.FindElements(By.CssSelector("span.text"));
                    foreach (IWebElement checkBox in checkBoxSpanList)
                    {
                        if (checkBox.Text.Equals(pendencia))
                        {
                            checkBox.Click();
                            //Valida se o checkbox foi selecionado

                            var checkBoxSelected = DriverSelenium.FindElement(By.CssSelector("div.checkbox-icon.fa-stack.selected")).FindElement(By.XPath("parent::*")).FindElement(By.CssSelector("span.text"));
                            if (checkBoxSelected.Text.Equals(pendencia))
                            {
                                //clica fora da div da pendencia para disparar o evento que irá mudar a lista
                                DriverSelenium.FindElement(By.CssSelector("div.v-table-header.cell.left")).Click();
                                Thread.Sleep(3000);
                                //Validação se a lista está com a pendencia selecionada
                                IReadOnlyCollection<IWebElement> list = DriverSelenium.FindElements(By.CssSelector("tr.clickable"));
                                if (list.Count > 0)
                                {
                                    foreach (IWebElement row in list)
                                    {
                                        if (row.FindElement(By.CssSelector("div.v-badge")).Text.ToUpper().Contains(deParaPend[pendencia]))
                                        {
                                            count++;
                                        }
                                    }
                                }
                                if (count >= ((list.Count *80)/100))
                                {
                                    retorno = "success";
                                    return retorno;
                                }
                                else
                                {
                                    retorno = "Falha na seleção da pendencia "+ pendencia;
                                    return retorno;
                                }
                            }
                        }
                    }
                }
            }catch(Exception err) {
                retorno = retorno + err;
            }
            return retorno;
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
    }
}
