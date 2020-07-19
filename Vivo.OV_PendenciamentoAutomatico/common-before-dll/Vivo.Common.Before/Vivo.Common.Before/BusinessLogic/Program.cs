using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo.Common.Before.BusinessLogic
{
    class Program
    {
        public static void SendEmail()
        {
            string url = "https://api-hml.telefonica.com.br/secure/healthcheck";
            WebService.GetResponse(url);
        }
    }
}
