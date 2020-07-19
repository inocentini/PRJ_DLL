using OpenQA.Selenium;
using Selenium.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DriverSelenium = Vivo.Common.Fwk.BusinessProcess.Selenium;

namespace Vivo.OV_PendenciamentoAutomatico.BL
{
    class BeforeScreen
    {
        internal static string user = "OV_BEFORE_USER";
        internal static string sunUrl = "OV_BEFORE_URL_SUN";
        internal static string vendasURL = "OV_BEFORE_URL_VENDAS";
        internal static string Login(string canal)
        {
            string retorno = "fail";
            if (canal.ToUpper().Contains("VAREJO"))
            {
                retorno = Vivo.Common.Before.Main.LoginB4(sunUrl, user, canal);
            }
            else
            {
                retorno = Vivo.Common.Before.Main.LoginB4(vendasURL, user, canal);
            }
            return retorno;
        }

        internal static string CloseChrome()
        {
            string retorno = "Fail";
            try
            {
                DriverSelenium.CloseQuitDriver();
                retorno = "success";

            }
            catch (Exception err)
            {
                retorno = retorno + err;
            }

            return retorno;
        }

        internal static string SearchVendaPendNaoLoc24()
        {   
            string retorno = "Fail";
            string obsDate;
            int count = 0;
            bool maior24h = false;
            try
            {
                Thread.Sleep(2000);
                IReadOnlyCollection<IWebElement> list = DriverSelenium.FindElements(By.CssSelector("tr.clickable"));
                foreach (IWebElement row in list)
                {
                    try
                    {
                        count = 0;
                        if (row.FindElement(By.CssSelector("td:nth-child(8)")).Text.ToUpper().Contains("P. NÃO LOC."))
                        {
                            foreach(IWebElement cell in row.FindElements(By.ClassName("cell")))
                            {
                                if(cell.GetAttribute("innerText").ToUpper().Contains("P. NÃO LOC."))
                                {
                                    cell.Click();
                                    break;
                                }
                            }
                            if (DriverSelenium.WaitToLoad(By.CssSelector("div.botoesListaItem.botoesItem.corBotaoInfo")))
                            {
                                DriverSelenium.FindElement(By.CssSelector("div.botoesListaItem.botoesItem.corBotaoInfo")).Click();
                                DriverSelenium.WaitToLoad(By.CssSelector("div.chat-obs"));
                                Thread.Sleep(2000);
                                IReadOnlyCollection<IWebElement> obsList = DriverSelenium.FindElement(By.CssSelector("div.chat-obs")).FindElements(By.CssSelector("div.chat-body.right"));
                                foreach (IWebElement obs in obsList)
                                {
                                    if (obs.FindElement(By.CssSelector("strong.status.pendente")).Text.ToUpper().Equals("PENDENTE NÃO LOCALIZADO"))
                                    {
                                        if (obs.FindElement(By.CssSelector("div.message-content")).Text.ToUpper().Contains("REALIZADO CONTATO COM O CLIENTE")
                                            && (obs.FindElement(By.CssSelector("div.message-content")).Text.ToUpper().Contains("SEM SUCESSO")
                                            || obs.FindElement(By.CssSelector("div.message-content")).Text.ToUpper().Contains("CLIENTE NÃO ATENDEU")))
                                        {
                                            count++;
                                            if (count == 1)
                                            {
                                                obsDate = obs.FindElement(By.CssSelector("div.message-date")).Text;
                                                string[] splited = obsDate.Split('-');
                                                obsDate = splited[1] + " " + splited[0];
                                                DateTime d1 = DateTime.Parse(obsDate);
                                                DateTime d2 = DateTime.Now;
                                                TimeSpan d1Tsmp = (d1 - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
                                                TimeSpan d2Tmsp = (d2 - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
                                                TimeSpan diff = (d2Tmsp - d1Tsmp);
                                                double result = diff.TotalMilliseconds / 1000;
                                                result /= 60;
                                                if (Math.Abs(Math.Round(result)) > 1440)
                                                {
                                                    maior24h = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (count >= 3 && maior24h)
                                {
                                    DriverSelenium.FindElement(By.CssSelector("img.x")).Click();
                                    retorno = row.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                                    return retorno;
                                }
                                else
                                {
                                    DriverSelenium.FindElement(By.CssSelector("img.x")).Click();
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                retorno = "Success";
            }catch (Exception err)
            {
                retorno = retorno + err;
            }
            return retorno;
        }

        internal static string SearchVendaPendVendedor24()
        {
            Regex pattern = new Regex(@"\d{1,2}d");
            string tmp;
            string retorno = "Fail";
            try
            {
                IReadOnlyCollection<IWebElement> list = DriverSelenium.FindElements(By.CssSelector("tr.clickable"));
                foreach (IWebElement row in list)
                {
                    if (row.FindElement(By.CssSelector("td:nth-child(8)")).Text.ToUpper().Equals("P. VENDEDOR"))
                    {
                        row.FindElement(By.CssSelector("div.v-menu-wrapper")).FindElement(By.CssSelector(".svg-icon")).Click();
                        if (DriverSelenium.WaitToLoad(By.CssSelector("div.menu-mask")))
                        {
                            tmp = row.FindElement(By.CssSelector("div.menu-items")).FindElement(By.CssSelector("span")).Text;
                            DriverSelenium.FindElement(By.CssSelector("div.menu-mask")).Click();
                            if (pattern.IsMatch(tmp))
                            {
                                retorno = row.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                                return retorno;
                            }
                        }
                    }
                }
                DriverSelenium.FindElement(By.CssSelector("div.menu-mask")).Click();
                retorno = "Success";
            }
            catch(Exception err)
            {
                retorno = retorno + err;
            }

            return retorno;
        }

        internal static string AccessHomePage()
        {
            string retorno = "fail";
            try
            {
                DriverSelenium.FindElement(By.CssSelector("i.fa.fa-home")).Click();
                if (DriverSelenium.WaitToLoad(By.CssSelector("div#capaAtalhos")))
                {
                    retorno = "success";
                }
            }catch (Exception err)
            {
                retorno = retorno + err;
            }
            return retorno;
        }
    }
}
