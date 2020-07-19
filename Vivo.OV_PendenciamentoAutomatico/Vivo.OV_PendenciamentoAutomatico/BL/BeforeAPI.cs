using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivo.OV_PendenciamentoAutomatico.Model;

namespace Vivo.OV_PendenciamentoAutomatico.BL
{
    public class BeforeAPI
    {

        public static string PegarVenda(string idVenda, string canal)
        {
            string retorno = "Fail";
            try
            {
                string response = Vivo.Common.Before.Main.PegarVenda(idVenda, canal);
                Newtonsoft.Json.Linq.JObject result = Newtonsoft.Json.Linq.JObject.Parse(response);
                string value = result.GetValue("codigo").ToString();
                if (value != "0")
                {
                    retorno = response;
                }
                else if (value == "0")
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("vendaJson", response) ;
                    JArray dataReader = JArray.Parse(ORM.DBConnection.ExecuteReader("operador_Virtual.addVenda_PendAut", null, parameters));
                    JObject dbResponse = dataReader.ElementAt(0).ToObject<JObject>();
                    retorno = dbResponse["idVenda"].ToString();                
                }

            }
            catch(Exception err)
            {
                retorno = retorno + err;
            }
            
            return retorno;

        }

        public static string PendenciarVenda(string idVenda, string canal,string idPendencia)
        {
            string retorno = "Fail";
            //Carregando Pendencia
            Pendencia pendencia = new Pendencia();
            pendencia = Pendencia.getPendencia(idPendencia);

            //Chamando método da dll commmon
            JObject response = JObject.Parse(Vivo.Common.Before.Main.PendenciarVenda(idVenda, canal, pendencia.api,pendencia.observacao));
            try
            {
                retorno = response["dados"]["mensagem"].ToString();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("idVenda", idVenda);
                parameters.Add("canal", canal);
                parameters.Add("status", pendencia.api);
                parameters.Add("idPendencia", idPendencia);
                parameters.Add("motivo", pendencia.observacao);
                JArray dbResponse = JArray.Parse(ORM.DBConnection.ExecuteReader("operador_Virtual.registraPendencia_PendAut", null, parameters));
                JObject dbParser = dbResponse.ElementAt(0).ToObject<JObject>();
                retorno = retorno + "idPendencia: " + dbParser["idPendencia"].ToString();
            }
            catch
            {
                retorno = retorno + response["mensagem"].ToString();
            }
            return retorno;
        }

        public static string FinalizarVenda(string idVenda, string canal, string idPendencia)
        {
            string retorno = "Fail";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idVenda", idVenda);
            parameters.Add("canal", canal);
            JArray dataReaderFinalizaParams = JArray.Parse(ORM.DBConnection.ExecuteReader("operador_Virtual.getAttrib_FinalizaVenda_PendAut", null, parameters));
            JObject venda = dataReaderFinalizaParams.ElementAt(0).ToObject<JObject>();
            Pendencia pendencia = new Pendencia();
            pendencia = Pendencia.getPendencia(idPendencia);
            //Chamando método da dll commmon
            JObject response = JObject.Parse(Vivo.Common.Before.Main.FinalizarVenda(idVenda,canal, pendencia.api,pendencia.observacao, venda));
            try
            {
                retorno = response["dados"]["mensagem"].ToString();
                parameters.Remove("idVenda");
                parameters.Remove("canal");
                parameters.Add("idVenda", idVenda);
                parameters.Add("canal", canal);
                parameters.Add("status", pendencia.api);
                parameters.Add("idPendencia", idPendencia);
                parameters.Add("motivo", pendencia.observacao);
                JArray dbResponse = JArray.Parse(ORM.DBConnection.ExecuteReader("operador_Virtual.registraPendencia_PendAut", null, parameters));
                JObject dbParser = dbResponse.ElementAt(0).ToObject<JObject>();
                retorno = retorno + "idPendencia: " + dbParser["idPendencia"].ToString();
            }
            catch
            {
                retorno = retorno + response["mensagem"].ToString();
            }

            return retorno;
        }
    }
}
