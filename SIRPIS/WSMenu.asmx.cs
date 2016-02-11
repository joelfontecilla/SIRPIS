using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Comun.Entidades;
using Controlador.Executor;

namespace SIRPIS
{
    /// <summary>
    /// Summary description for WSMenu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSMenu : System.Web.Services.WebService
    {
        private MenuExecutor _executor = new MenuExecutor();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Menu[] GetAllDeparments()
        {
            return _executor.ExcuteConsultAllDeparment();
        }
    }
}
