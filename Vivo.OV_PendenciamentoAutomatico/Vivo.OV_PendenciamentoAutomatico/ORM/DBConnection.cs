using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo.OV_PendenciamentoAutomatico.ORM
{
    class DBConnection
    {
        internal static string stringConnection = "OPVIRT_DB_CONN";
        internal static void ExecuteNonQuery(string StoredProcedure, string ConnectionString = null, Dictionary<string, string> Parameters = null)
        {
            Parameters = Parameters ?? new Dictionary<string, string>();
            ConnectionString = ConnectionString ?? Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter(stringConnection)));
            Vivo.Common.Fwk.Dll.Util.ExecuteNonQuery(StoredProcedure, ConnectionString, Parameters);
        }

        internal static string ExecuteReader(string StoredProcedure, string ConnectionString = null, Dictionary<string, string> Parameters = null)
        {
            Parameters = Parameters ?? new Dictionary<string, string>();
            ConnectionString = ConnectionString ?? Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter(stringConnection)));
            return Vivo.Common.Fwk.Dll.Util.ExecuteReader(StoredProcedure, ConnectionString, Parameters);
        }

        internal static string ExecuteQuery(string query, string ConnectionString = null, Dictionary<string, string> Parameters = null)
        {
            Parameters = Parameters ?? new Dictionary<string, string>();
            ConnectionString = ConnectionString ?? Encoding.UTF8.GetString(Convert.FromBase64String(Common.Fwk.Dll.Util.GetParameter(stringConnection)));
            return Vivo.Common.Fwk.Dll.Util.ExecuteQuery(query, ConnectionString, Parameters);
        }
    }
}
