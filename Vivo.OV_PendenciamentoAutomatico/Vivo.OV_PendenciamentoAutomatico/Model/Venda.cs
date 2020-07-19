using Direct.Shared;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo.OV_PendenciamentoAutomatico.Model
{
    [DirectDom("Venda", "OperadorVirtual", false)]
    public class Venda : DirectComponentBase
    {
        protected PropertyHolder<string> _idVenda;
        protected PropertyHolder<string> _canal;

        public Venda(JObject obj) : this()
        {
            if (obj.TryGetValue("idVenda", out JToken idVendaTmp)) idVenda = idVendaTmp.Value<string>();
            if (obj.TryGetValue("canal", out JToken canalTmp)) canal = canalTmp.Value<string>();

        }

        public Venda()
        {
            _idVenda = new PropertyHolder<string>("idVenda");
            _canal = new PropertyHolder<string>("canal");
        }

        public Venda(IProject project) : base(project)
        {
            _idVenda = new PropertyHolder<string>("idVenda");
            _canal = new PropertyHolder<string>("canal");
        }

        [DirectDom("idVenda"), DesignTimeInfo("idVenda")]
        public string idVenda
        {
            get => _idVenda.TypedValue;
            set => _idVenda.TypedValue = value;
        }

        [DirectDom("canal"), DesignTimeInfo("canal")]
        public string canal
        {
            get => _canal.TypedValue;
            set => _canal.TypedValue = value;
        }
    }
}
