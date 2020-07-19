using Direct.Shared;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo.OV_PendenciamentoAutomatico.Model
{
    [DirectDom("FinalizarVendaParam", "OperadorVirtual", false)]
    public class FinalizarVendaParams : DirectComponentBase
    {

        protected PropertyHolder<string> _venda;
        protected PropertyHolder<string> _observacao;
        protected PropertyHolder<string> _codigo;
        protected PropertyHolder<string> _status;
        protected PropertyHolder<string> _idPlano;
        protected PropertyHolder<string> _nomePlano;
        protected PropertyHolder<string> _produto;
        protected PropertyHolder<string> _ddd;
        protected PropertyHolder<string> _tipoServico;
        protected PropertyHolder<string> _portabilidade;
        protected PropertyHolder<string> _idOperadora;
        protected PropertyHolder<string> _nomeOperadora;
        protected PropertyHolder<string> _numeroProvisorio;
        protected PropertyHolder<string> _fidelizacao;
        protected PropertyHolder<string> _numeroLinha;
        protected PropertyHolder<string> _iccid;
        protected PropertyHolder<string> _tipoFatura;
        protected PropertyHolder<string> _formatoPagamento;
        protected PropertyHolder<string> _idBanco;
        protected PropertyHolder<string> _numeroAgencia;
        protected PropertyHolder<string> _numeroConta;
        protected PropertyHolder<string> _vencimento;
        protected PropertyHolder<string> _trocaTitularidade;
        protected PropertyHolder<string> _protocolo;
        protected PropertyHolder<string> _cpf;
        protected PropertyHolder<string> _nome;
        protected PropertyHolder<string> _sexo;
        protected PropertyHolder<string> _nomeMae;
        protected PropertyHolder<string> _dataNascimento;
        protected PropertyHolder<string> _telefone1;
        protected PropertyHolder<string> _cep;
        protected PropertyHolder<string> _logradouro;
        protected PropertyHolder<string> _bairro;
        protected PropertyHolder<string> _numero;
        protected PropertyHolder<string> _semNumero;
        protected PropertyHolder<string> _cidade;
        protected PropertyHolder<string> _uf;
        protected PropertyHolder<string> _email;

        public FinalizarVendaParams(JObject obj) : this()
        {
            if (obj.TryGetValue("idVenda", out JToken vendaTmp)) venda = vendaTmp.Value<string>();
            if (obj.TryGetValue("codigo", out JToken codigoTmp)) codigo = codigoTmp.Value<string>();
            if (obj.TryGetValue("status", out JToken statusTmp)) status = statusTmp.Value<string>();
            if (obj.TryGetValue("idPlano", out JToken idPlanoTmp)) idPlano = idPlanoTmp.Value<string>();
            if (obj.TryGetValue("nomePlano", out JToken nomePlanoTmp)) nomePlano = nomePlanoTmp.Value<string>();
            if (obj.TryGetValue("produto", out JToken produtoTmp)) produto = produtoTmp.Value<string>();
            if (obj.TryGetValue("ddd", out JToken dddTmp)) ddd = dddTmp.Value<string>();
            if (obj.TryGetValue("tipoServico", out JToken tipoServTmp)) tipoServico = tipoServTmp.Value<string>();
            if (obj.TryGetValue("portabilidade", out JToken portabilidadeTmp)) portabilidade = portabilidadeTmp.Value<string>();
            if (obj.TryGetValue("idOperadora", out JToken idOperadoraTmp)) idOperadora = idOperadoraTmp.Value<string>();
            if (obj.TryGetValue("nomeOperadora", out JToken nomeOperadoraTmp)) nomeOperadora = nomeOperadoraTmp.Value<string>();
            if (obj.TryGetValue("numeroProvisorio", out JToken numeroProvisorioTmp)) numeroProvisorio = numeroProvisorioTmp.Value<string>();
            if (obj.TryGetValue("fidelizacao", out JToken fidelizacaoTmp)) fidelizacao = fidelizacaoTmp.Value<string>();
            if (obj.TryGetValue("numeroLinha", out JToken numeroLinhaTmp)) numeroLinha = numeroLinhaTmp.Value<string>();
            if (obj.TryGetValue("iccid", out JToken iccidTmp)) iccid = iccidTmp.Value<string>();
            if (obj.TryGetValue("tipoFatura", out JToken tipoFaturaTmp)) tipoFatura = tipoFaturaTmp.Value<string>();
            if (obj.TryGetValue("formatoPagamento", out JToken formatoPagamentoTmp)) formatoPagamento = formatoPagamentoTmp.Value<string>();
            if (obj.TryGetValue("idBanco", out JToken idBancoTmp)) idBanco = idBancoTmp.Value<string>();
            if (obj.TryGetValue("numeroAgencia", out JToken numeroAgenciaTmp)) numeroAgencia = numeroAgenciaTmp.Value<string>();
            if (obj.TryGetValue("numeroConta", out JToken numeroContaTmp)) numeroConta = numeroContaTmp.Value<string>();
            if (obj.TryGetValue("vencimento", out JToken vencimentoTmp)) vencimento = vencimentoTmp.Value<string>();
            if (obj.TryGetValue("trocaTitularidade", out JToken trocaTitularidadeTmp)) trocaTitularidade = trocaTitularidadeTmp.Value<string>();
            if (obj.TryGetValue("protocolo", out JToken protocoloTmp)) protocolo = protocoloTmp.Value<string>();
            if (obj.TryGetValue("cpf", out JToken cpfTmp)) cpf = cpfTmp.Value<string>();
            if (obj.TryGetValue("nome", out JToken nomeTmp)) nome = nomeTmp.Value<string>();
            if (obj.TryGetValue("sexo", out JToken sexoTmp)) sexo = sexoTmp.Value<string>();
            if (obj.TryGetValue("nomeMae", out JToken nomeMaeTmp)) nomeMae = nomeMaeTmp.Value<string>();
            if (obj.TryGetValue("dataNascimento", out JToken dataNascTmp)) dataNascimento = dataNascTmp.Value<string>();
            if (obj.TryGetValue("telefone1", out JToken telefone1Tmp)) telefone1 = telefone1Tmp.Value<string>();
            if (obj.TryGetValue("cep", out JToken cepTmp)) cep = cepTmp.Value<string>();
            if (obj.TryGetValue("logradouro", out JToken lograTmp)) logradouro = lograTmp.Value<string>();
            if (obj.TryGetValue("bairro", out JToken bairroTmp)) bairro = bairroTmp.Value<string>();
            if (obj.TryGetValue("numero", out JToken numeroTmp)) numero = numeroTmp.Value<string>();
            if (obj.TryGetValue("semNumero", out JToken semNumeroTmp)) semNumero = semNumeroTmp.Value<string>();
            if (obj.TryGetValue("cidade", out JToken cidadeTmp)) cidade = cidadeTmp.Value<string>();
            if (obj.TryGetValue("uf", out JToken ufTmp)) uf = ufTmp.Value<string>();
            if (obj.TryGetValue("email", out JToken emailTmp)) email = emailTmp.Value<string>();

        }
        public FinalizarVendaParams()
        {
            _venda = new PropertyHolder<string>("venda");
            _observacao = new PropertyHolder<string>("observacao");
            _codigo = new PropertyHolder<string>("codigo");
            _status = new PropertyHolder<string>("status");
            _idPlano = new PropertyHolder<string>("idPlano");
            _nomePlano = new PropertyHolder<string>("nomePlano");
            _produto = new PropertyHolder<string>("produto");
            _ddd = new PropertyHolder<string>("ddd");
            _tipoServico = new PropertyHolder<string>("tipoServico");
            _portabilidade = new PropertyHolder<string>("portabilidade");
            _idOperadora = new PropertyHolder<string>("idOperadora");
            _nomeOperadora = new PropertyHolder<string>("nomeOperadora");
            _numeroProvisorio = new PropertyHolder<string>("numeroProvisorio");
            _fidelizacao = new PropertyHolder<string>("fidelizacao");
            _numeroLinha = new PropertyHolder<string>("numeroLinha");
            _iccid = new PropertyHolder<string>("iccid");
            _tipoFatura = new PropertyHolder<string>("tipoFatura");
            _formatoPagamento = new PropertyHolder<string>("formatoPagamento");
            _idBanco = new PropertyHolder<string>("idBanco");
            _numeroAgencia = new PropertyHolder<string>("numeroAgencia");
            _numeroConta = new PropertyHolder<string>("numeroConta");
            _vencimento = new PropertyHolder<string>("vencimento");
            _trocaTitularidade = new PropertyHolder<string>("trocaTitularidade");
            _protocolo = new PropertyHolder<string>("protocolo");
            _cpf = new PropertyHolder<string>("cpf");
            _nome = new PropertyHolder<string>("nome");
            _sexo = new PropertyHolder<string>("sexo");
            _nomeMae = new PropertyHolder<string>("nomeMae");
            _dataNascimento = new PropertyHolder<string>("dataNascimento");
            _telefone1 = new PropertyHolder<string>("telefone1");
            _cep = new PropertyHolder<string>("cep");
            _logradouro = new PropertyHolder<string>("logradouro");
            _bairro = new PropertyHolder<string>("bairro");
            _numero = new PropertyHolder<string>("numero");
            _semNumero = new PropertyHolder<string>("semNumero");
            _cidade = new PropertyHolder<string>("cidade");
            _uf = new PropertyHolder<string>("uf");
            _email = new PropertyHolder<string>("email");
        }

        public FinalizarVendaParams(IProject project) : base(project)
        {
            _venda = new PropertyHolder<string>("venda");
            _observacao = new PropertyHolder<string>("observacao");
            _codigo = new PropertyHolder<string>("codigo");
            _status = new PropertyHolder<string>("status");
            _idPlano = new PropertyHolder<string>("idPlano");
            _nomePlano = new PropertyHolder<string>("nomePlano");
            _produto = new PropertyHolder<string>("produto");
            _ddd = new PropertyHolder<string>("ddd");
            _tipoServico = new PropertyHolder<string>("tipoServico");
            _portabilidade = new PropertyHolder<string>("portabilidade");
            _idOperadora = new PropertyHolder<string>("idOperadora");
            _nomeOperadora = new PropertyHolder<string>("nomeOperadora");
            _numeroProvisorio = new PropertyHolder<string>("numeroProvisorio");
            _fidelizacao = new PropertyHolder<string>("fidelizacao");
            _numeroLinha = new PropertyHolder<string>("numeroLinha");
            _iccid = new PropertyHolder<string>("iccid");
            _tipoFatura = new PropertyHolder<string>("tipoFatura");
            _formatoPagamento = new PropertyHolder<string>("formatoPagamento");
            _idBanco = new PropertyHolder<string>("idBanco");
            _numeroAgencia = new PropertyHolder<string>("numeroAgencia");
            _numeroConta = new PropertyHolder<string>("numeroConta");
            _vencimento = new PropertyHolder<string>("vencimento");
            _trocaTitularidade = new PropertyHolder<string>("trocaTitularidade");
            _protocolo = new PropertyHolder<string>("protocolo");
            _cpf = new PropertyHolder<string>("cpf");
            _nome = new PropertyHolder<string>("nome");
            _sexo = new PropertyHolder<string>("sexo");
            _nomeMae = new PropertyHolder<string>("nomeMae");
            _dataNascimento = new PropertyHolder<string>("dataNascimento");
            _telefone1 = new PropertyHolder<string>("telefone1");
            _cep = new PropertyHolder<string>("cep");
            _logradouro = new PropertyHolder<string>("logradouro");
            _bairro = new PropertyHolder<string>("bairro");
            _numero = new PropertyHolder<string>("numero");
            _semNumero = new PropertyHolder<string>("semNumero");
            _cidade = new PropertyHolder<string>("cidade");
            _uf = new PropertyHolder<string>("uf");
            _email = new PropertyHolder<string>("email");
        }

        [DirectDom("venda"), DesignTimeInfo("venda")]
        public string venda
        {
            get => _venda.TypedValue;
            set => _venda.TypedValue = value;
        }

        [DirectDom("observacao"), DesignTimeInfo("observacao")]
        public string observacao
        {
            get => _observacao.TypedValue;
            set => _observacao.TypedValue = value;
        }

        [DirectDom("codigo"), DesignTimeInfo("codigo")]
        public string codigo
        {
            get => _codigo.TypedValue;
            set => _codigo.TypedValue = value;
        }

        [DirectDom("status"), DesignTimeInfo("status")]
        public string status
        {
            get => _status.TypedValue;
            set => _status.TypedValue = value;
        }

        [DirectDom("idPlano"), DesignTimeInfo("idPlano")]
        public string idPlano
        {
            get => _idPlano.TypedValue;
            set => _idPlano.TypedValue = value;
        }

        [DirectDom("nomePlano"), DesignTimeInfo("nomePlano")]
        public string nomePlano
        {
            get => _nomePlano.TypedValue;
            set => _nomePlano.TypedValue = value;
        }

        [DirectDom("produto"), DesignTimeInfo("produto")]
        public string produto
        {
            get => _produto.TypedValue;
            set => _produto.TypedValue = value;
        }

        [DirectDom("ddd"), DesignTimeInfo("ddd")]
        public string ddd
        {
            get => _ddd.TypedValue;
            set => _ddd.TypedValue = value;
        }

        [DirectDom("tipoServico"), DesignTimeInfo("tipoServico")]
        public string tipoServico
        {
            get => _tipoServico.TypedValue;
            set => _tipoServico.TypedValue = value;
        }

        [DirectDom("portabilidade"), DesignTimeInfo("portabilidade")]
        public string portabilidade
        {
            get => _portabilidade.TypedValue;
            set => _portabilidade.TypedValue = value;
        }

        [DirectDom("idOperadora"), DesignTimeInfo("idOperadora")]
        public string idOperadora
        {
            get => _idOperadora.TypedValue;
            set => _idOperadora.TypedValue = value;
        }

        [DirectDom("nomeOperadora"), DesignTimeInfo("nomeOperadora")]
        public string nomeOperadora
        {
            get => _nomeOperadora.TypedValue;
            set => _nomeOperadora.TypedValue = value;
        }

        [DirectDom("numeroProvisorio"), DesignTimeInfo("numeroProvisorio")]
        public string numeroProvisorio
        {
            get => _numeroProvisorio.TypedValue;
            set => _numeroProvisorio.TypedValue = value;
        }

        [DirectDom("fidelizacao"), DesignTimeInfo("fidelizacao")]
        public string fidelizacao
        {
            get => _fidelizacao.TypedValue;
            set => _fidelizacao.TypedValue = value;
        }

        [DirectDom("numeroLinha"), DesignTimeInfo("numeroLinha")]
        public string numeroLinha
        {
            get => _numeroLinha.TypedValue;
            set => _numeroLinha.TypedValue = value;
        }

        [DirectDom("iccid"), DesignTimeInfo("iccid")]
        public string iccid
        {
            get => _iccid.TypedValue;
            set => _iccid.TypedValue = value;
        }

        [DirectDom("tipoFatura"), DesignTimeInfo("tipoFatura")]
        public string tipoFatura
        {
            get => _tipoFatura.TypedValue;
            set => _tipoFatura.TypedValue = value;
        }

        [DirectDom("formatoPagamento"), DesignTimeInfo("formatoPagamento")]
        public string formatoPagamento
        {
            get => _formatoPagamento.TypedValue;
            set => _formatoPagamento.TypedValue = value;
        }

        [DirectDom("idBanco"), DesignTimeInfo("idBanco")]
        public string idBanco
        {
            get => _idBanco.TypedValue;
            set => _idBanco.TypedValue = value;
        }

        [DirectDom("numeroAgencia"), DesignTimeInfo("numeroAgencia")]
        public string numeroAgencia
        {
            get => _numeroAgencia.TypedValue;
            set => _numeroAgencia.TypedValue = value;
        }

        [DirectDom("numeroConta"), DesignTimeInfo("numeroConta")]
        public string numeroConta
        {
            get => _numeroConta.TypedValue;
            set => _numeroConta.TypedValue = value;
        }


        [DirectDom("vencimento"), DesignTimeInfo("vencimento")]
        public string vencimento
        {
            get => _vencimento.TypedValue;
            set => _vencimento.TypedValue = value;
        }

        [DirectDom("trocaTitularidade"), DesignTimeInfo("trocaTitularidade")]
        public string trocaTitularidade
        {
            get => _trocaTitularidade.TypedValue;
            set => _trocaTitularidade.TypedValue = value;
        }

        [DirectDom("protocolo"), DesignTimeInfo("protocolo")]
        public string protocolo
        {
            get => _protocolo.TypedValue;
            set => _protocolo.TypedValue = value;
        }

        [DirectDom("cpf"), DesignTimeInfo("cpf")]
        public string cpf
        {
            get => _cpf.TypedValue;
            set => _cpf.TypedValue = value;
        }

        [DirectDom("nome"), DesignTimeInfo("nome")]
        public string nome
        {
            get => _nome.TypedValue;
            set => _nome.TypedValue = value;
        }

        [DirectDom("sexo"), DesignTimeInfo("sexo")]
        public string sexo
        {
            get => _sexo.TypedValue;
            set => _sexo.TypedValue = value;
        }

        [DirectDom("nomeMae"), DesignTimeInfo("nomeMae")]
        public string nomeMae
        {
            get => _nomeMae.TypedValue;
            set => _nomeMae.TypedValue = value;
        }

        [DirectDom("dataNascimento"), DesignTimeInfo("dataNascimento")]
        public string dataNascimento
        {
            get => _dataNascimento.TypedValue;
            set => _dataNascimento.TypedValue = value;
        }

        [DirectDom("telefone1"), DesignTimeInfo("telefone1")]
        public string telefone1
        {
            get => _telefone1.TypedValue;
            set => _telefone1.TypedValue = value;
        }

        [DirectDom("cep"), DesignTimeInfo("cep")]
        public string cep
        {
            get => _cep.TypedValue;
            set => _cep.TypedValue = value;
        }

        [DirectDom("logradouro"), DesignTimeInfo("logradouro")]
        public string logradouro
        {
            get => _logradouro.TypedValue;
            set => _logradouro.TypedValue = value;
        }

        [DirectDom("bairro"), DesignTimeInfo("bairro")]
        public string bairro
        {
            get => _bairro.TypedValue;
            set => _bairro.TypedValue = value;
        }

        [DirectDom("numero"), DesignTimeInfo("numero")]
        public string numero
        {
            get => _numero.TypedValue;
            set => _numero.TypedValue = value;
        }

        [DirectDom("semNumero"), DesignTimeInfo("semNumero")]
        public string semNumero
        {
            get => _semNumero.TypedValue;
            set => _semNumero.TypedValue = value;
        }

        [DirectDom("cidade"), DesignTimeInfo("cidade")]
        public string cidade
        {
            get => _cidade.TypedValue;
            set => _cidade.TypedValue = value;
        }

        [DirectDom("uf"), DesignTimeInfo("uf")]
        public string uf
        {
            get => _uf.TypedValue;
            set => _uf.TypedValue = value;
        }

        [DirectDom("email"), DesignTimeInfo("email")]
        public string email
        {
            get => _email.TypedValue;
            set => _email.TypedValue = value;
        }

        public static FinalizarVendaParams fillParams(string idVenda, string canal)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idVenda", idVenda);
            parameters.Add("canal", canal);
            JArray response = JArray.Parse(ORM.DBConnection.ExecuteReader("operador_Virtual.getAttrib_FinalizaVenda_PendAut", null, parameters));
            JObject venda = response.ElementAt(0).ToObject<JObject>();
            return new FinalizarVendaParams(venda);
        }

    }
}
