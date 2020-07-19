using Direct.Shared;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo.OV_PendenciamentoAutomatico.Model
{
    [DirectDom("Pendencia", "OperadorVirtual", false)]
    public class Pendencia : DirectComponentBase
    {
        protected PropertyHolder<string> _observacao;
        protected PropertyHolder<string> _api;

        public Pendencia(JObject obj) : this()
        {
            if (obj.TryGetValue("observacao", out JToken observacaoTmp)) observacao = observacaoTmp.Value<string>();
            if (obj.TryGetValue("api", out JToken apiTmp)) api = apiTmp.Value<string>();

        }

        public Pendencia()
        {
            _observacao = new PropertyHolder<string>("observacao");
            _api = new PropertyHolder<string>("api");
        }

        public Pendencia(IProject project) : base(project)
        {
            _observacao = new PropertyHolder<string>("observacao");
            _api = new PropertyHolder<string>("api");
        }

        [DirectDom("observacao"), DesignTimeInfo("observacao")]
        public string observacao
        {
            get => _observacao.TypedValue;
            set => _observacao.TypedValue = value;
        }

        [DirectDom("api"), DesignTimeInfo("api")]
        public string api
        {
            get => _api.TypedValue;
            set => _api.TypedValue = value;
        }

        public static Pendencia getPendencia(string idPendencia)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idPendencia", idPendencia);
            JArray response = JArray.Parse(ORM.DBConnection.ExecuteReader("operador_Virtual.getPendencia", null, parameters));
            JObject venda = response.ElementAt(0).ToObject<JObject>();
            return new Pendencia(venda);
        }
    }
}
