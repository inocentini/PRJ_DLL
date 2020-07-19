using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Remote;
using Renci.SshNet.Messages.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo.Common.Before.BusinessLogic
{
    public static class Rest
    {
        //Get API user
        internal static string user = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter("OPVIRT_API_BEFORE_USER")));
        //Get Token SUN
        internal static string tokenSun = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter("OPVIRT_API_BEFORE_SUN_TOKEN")));
        //Get Token Vendas
        internal static string tokenVendas = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter("OPVIRT_API_BEFORE_VENDAS_TOKEN")));
        //Get endPoint pegarVenda
        internal static string pegarVendaURL = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter("OPVIRT_API_BEFORE_PEGARVENDA")));
        //Get endPoint pendenciarVenda
        internal static string pendenciarVendaURL = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter("OPVIRT_API_BEFORE_PENDENCIAR")));
        //Get endPoint Finalizar Venda
        internal static string finalizarVendaURL = Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter("OPVIRT_API_BEFORE_FINALIZARVENDA")));
        internal static string PegarVenda(string canal)
        {
            string retorno = "Fail";
            string token;
            if (canal.ToUpper().Contains("VAREJO"))
            {
                token = tokenSun;
            }
            else
            {
                token = tokenVendas;
            }
            //Montagem do corpo da requisição
            string body = "{\"usuario\": \"" + user + "\"}";
            //Send Request
            return retorno = Vivo.Common.Before.Main.GetResponse(pegarVendaURL, token, body);           
        }

        internal static string PegarVenda(string idVenda, string canal)
        {
            string retorno = "Fail";
            string token;
            if (canal.ToUpper().Contains("VAREJO"))
            {
                token = tokenSun;
            }
            else
            {
                token = tokenVendas;
            }
            //Montagem do corpo da requisição
            string body = "{\n\t\t\"usuario\": \"" + user + "\",\n\t\t"
                + "\"venda\":\""+idVenda+"\"\n}";
            return retorno = Vivo.Common.Before.Main.GetResponse(pegarVendaURL, token, body);
        }

        public static string PendenciarVenda(string idVenda,string canal, string idPendenciaAPI, string observacao)
        {
            string token;
            if (canal.ToUpper().Contains("VAREJO"))
            {
                token = tokenSun;
            }
            else
            {
                token = tokenVendas;
            }
 
            //Montagem do corpo da requisição
            string body = "{\n\t\"venda\": \"" + idVenda + "\",\n\t"
                + "\"usuario\": \"" + user + "\",\n\t"
                + "\"pendencia\": \"" + idPendenciaAPI + "\",\n\t"
                + "\"observacao\": \"" +observacao + "\"\n}";
            //Chamando método da dll commmon
            return Vivo.Common.Before.Main.GetResponse(pendenciarVendaURL, token, body);
        }

        public static string PendenciarVendaAgendamento(string idVenda,string canal, string idPendenciaAPI,string observacao, string data, string hora)
        {
            string token;
            if (canal.ToUpper().Contains("VAREJO"))
            {
                token = tokenSun;
            }
            else
            {
                token = tokenVendas;
            }


            //Montagem do corpo da requisição
            string body = "{\n\t\"venda\": \"" + idVenda + "\",\n\t"
                + "\"usuario\": \"" + user + "\",\n\t"
                + "\"pendencia\": \"" + idPendenciaAPI + "\",\n\t"
                + "\"observacao\": \"" + observacao + "\",\n\t"
                + "\"agendamento\":\n{\n\t"
                + "\"data\": \"" + data + "\",\n\t"
                + "\"hora\": \"" + hora + "\"\n}";
            //Chamando método da dll commmon
            return Vivo.Common.Before.Main.GetResponse(pendenciarVendaURL, token, body);
        }

        public static string FinalizarVenda(string idVenda, string canal,string idPendenciaAPI,string observacao, JObject venda)
        {
            string token;
            if (canal.ToUpper().Contains("VAREJO"))
            {
                token = tokenSun;

            }
            else
            {
                token = tokenVendas;
            }

            string body;
            
            if (venda.GetValue("portabilidade").ToString().ToUpper().Contains("TRUE"))
            {
                body = "{\n\t\"usuario\": \"" + user + "\",\n\t"
                    + "\"venda\": \"" + idVenda + "\",\n\t"
                    + "\"observacao\": \"" + observacao + "\",\n\t"
                    + "\"servicos\": [\n\t{\n\t\t"
                    + "\"codigo\": \"" + venda.GetValue("codigo").ToString() + "\",\n\t\t"
                    + "\"status\": \"" + idPendenciaAPI + "\",\n\t\t"
                    + "\"idPlano\": \"" + venda.GetValue("idPlano").ToString() + "\",\n\t\t"
                    + "\"nomePlano\": \"" + venda.GetValue("nomePlano").ToString() + "\",\n\t\t"
                    + "\"produto\": \"" + venda.GetValue("produto").ToString() + "\",\n\t\t"
                    + "\"ddd\": \"" + venda.GetValue("ddd").ToString() + "\",\n\t\t"
                    + "\"tipoServico\": \"" + venda.GetValue("tipoServico").ToString() + "\",\n\t\t"
                    + "\"portabilidade\": \"" + venda.GetValue("portabilidade").ToString() + "\",\n\t\t"
                    + "\"dadosPortabilidade\": { \n\t\t\t\t"
                    + "\"idOperadora\": \"" + venda.GetValue("idOperadora").ToString() + "\",\n\t\t\t\t"
                    + "\"nomeOperadora\":\"" + venda.GetValue("nomeOperadora").ToString() + "\",\n\t\t\t\t"
                    + "\"numeroProvisosrio\":\"" + venda.GetValue("numeroProvisosrio").ToString() + "\",\n\t\t\t\t"
                    + "\"numeroPortabilidade\":\"" + venda.GetValue("numeroPortabilidade").ToString() + "\"\n\t\t},\n\t\t"
                    + "\"fidelizacao\": \"" + venda.GetValue("fidelizacao").ToString() + "\",\n\t\t"
                    + "\"numeroLinha\": \"" + venda.GetValue("numeroLinha").ToString() + "\",\n\t\t"
                    + "\"iccid\": \"" + venda.GetValue("iccid").ToString() + "\",\n\t\t"
                    + "\"tipoFatura\": \"" + venda.GetValue("tipoFatura").ToString() + "\",\n\t\t"
                    + "\"vencimento\": \"" + venda.GetValue("vencimento").ToString() + "\",\n\t\t"
                    + "\"d0\": \"0\",\n\t\t"
                    + "\"origemAtendimento\": \"1\",\n\t\t"
                    + "\"trocaTitularidade\": \"" + venda.GetValue("trocaTitularidade").ToString() + "\",\n\t\t"
                    + "\"protocolo\": \"" + venda.GetValue("protocolo").ToString() + "\"\n\t}\n],"
                    + "\"cliente\":\n\t{\n\t\t"
                    + "\"cpf\": \"" + venda.GetValue("cpf").ToString() + "\",\n\t\t"
                    + "\"nome\": \"" + venda.GetValue("nome").ToString() + "\",\n\t\t"
                    + "\"sexo\": \"" + venda.GetValue("sexo").ToString() + "\",\n\t\t"
                    + "\"nomeMae\": \"" + venda.GetValue("nomeMae").ToString() + "\",\n\t\t"
                    + "\"dataNascimento\": \"" + venda.GetValue("dataNascimento").ToString() + "\",\n\t\t"
                    + "\"telefone1\": \"" + venda.GetValue("telefone1").ToString() + "\",\n\t\t"
                    + "\"cep\": \"" + venda.GetValue("cep").ToString() + "\",\n\t\t"
                    + "\"logradouro\": \"" + venda.GetValue("logradouro").ToString() + "\",\n\t\t"
                    + "\"bairro\": \"" + venda.GetValue("bairro").ToString() + "\",\n\t\t"
                    + "\"numero\": \"" + venda.GetValue("numero").ToString() + "\",\n\t\t"
                    + "\"semNumero\": \"" + venda.GetValue("semNumero").ToString() + "\",\n\t\t"
                    + "\"cidade\": \"" + venda.GetValue("cidade").ToString() + "\",\n\t\t"
                    + "\"uf\": \"" + venda.GetValue("uf").ToString() + "\",\n\t\t"
                    + "\"email\": \"" + venda.GetValue("email").ToString() + "\"\n\t}\n}";
            }
            else
            {
                body = "{\n\t\"usuario\": \"" + user + "\",\n\t"
                        + "\"venda\": \"" + idVenda + "\",\n\t"
                        + "\"observacao\": \"" + observacao + "\",\n\t"
                        + "\"servicos\": [\n\t{\n\t\t"
                        + "\"codigo\": \"" + venda.GetValue("codigo").ToString() + "\",\n\t\t"
                        + "\"status\": \"" + idPendenciaAPI + "\",\n\t\t"
                        + "\"idPlano\": \"" + venda.GetValue("idPlano").ToString() + "\",\n\t\t"
                        + "\"nomePlano\": \"" + venda.GetValue("nomePlano").ToString() + "\",\n\t\t"
                        + "\"produto\": \"" + venda.GetValue("produto").ToString() + "\",\n\t\t"
                        + "\"ddd\": \"" + venda.GetValue("ddd").ToString() + "\",\n\t\t"
                        + "\"tipoServico\": \"" + venda.GetValue("tipoServico").ToString() + "\",\n\t\t"
                        + "\"portabilidade\": \"" + venda.GetValue("portabilidade").ToString() + "\",\n\t\t"
                        + "\"fidelizacao\": \"" + venda.GetValue("fidelizacao").ToString() + "\",\n\t\t"
                        + "\"numeroLinha\": \"" + venda.GetValue("numeroLinha").ToString() + "\",\n\t\t"
                        + "\"iccid\": \"" + venda.GetValue("iccid").ToString() + "\",\n\t\t"
                        + "\"tipoFatura\": \"" + venda.GetValue("tipoFatura").ToString() + "\",\n\t\t"
                        + "\"vencimento\": \"" + venda.GetValue("vencimento").ToString() + "\",\n\t\t"
                        + "\"d0\": \"0\",\n\t\t"
                        + "\"origemAtendimento\": \"1\",\n\t\t"
                        + "\"trocaTitularidade\": \"" + venda.GetValue("trocaTitularidade").ToString() + "\",\n\t\t"
                        + "\"protocolo\": \"" + venda.GetValue("protocolo").ToString() + "\"\n\t}\n],"
                        + "\"cliente\":\n\t{\n\t\t"
                        + "\"cpf\": \"" + venda.GetValue("cpf").ToString() + "\",\n\t\t"
                        + "\"nome\": \"" + venda.GetValue("nome").ToString() + "\",\n\t\t"
                        + "\"sexo\": \"" + venda.GetValue("sexo").ToString() + "\",\n\t\t"
                        + "\"nomeMae\": \"" + venda.GetValue("nomeMae").ToString() + "\",\n\t\t"
                        + "\"dataNascimento\": \"" + venda.GetValue("dataNascimento").ToString() + "\",\n\t\t"
                        + "\"telefone1\": \"" + venda.GetValue("telefone1").ToString() + "\",\n\t\t"
                        + "\"cep\": \"" + venda.GetValue("cep").ToString() + "\",\n\t\t"
                        + "\"logradouro\": \"" + venda.GetValue("logradouro").ToString() + "\",\n\t\t"
                        //+ "\"bairro\": \"" + venda.GetValue("bairro").ToString() + "\",\n\t\t"
                        + "\"bairro\": \" Teste\",\n\t\t"
                        + "\"numero\": \"" + venda.GetValue("numero").ToString() + "\",\n\t\t"
                        + "\"semNumero\": \"" + venda.GetValue("semNumero").ToString() + "\",\n\t\t"
                        + "\"cidade\": \"" + venda.GetValue("cidade").ToString() + "\",\n\t\t"
                        + "\"uf\": \"" + venda.GetValue("uf").ToString() + "\",\n\t\t"
                        + "\"email\": \"" + venda.GetValue("email").ToString() + "\"\n\t}\n}";
            } 
            //Chamando método da dll commmon
            return Vivo.Common.Before.Main.GetResponse(finalizarVendaURL, token, body);
        }
    }
}
