using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Restaurant.DataLayer;
using Restaurant.BusinessLayer;
using System.Web.Script.Serialization;


namespace Restaurant
{
    /// <summary>
    /// Summary description for Ajax
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Ajax : System.Web.Services.WebService
    {
        [WebMethod]
        public void People(string val)
        {
            int broj = Convert.ToInt32(val);
            BrojLjudiInsert op = new BrojLjudiInsert { brojLjudi = new BrojLjudiItem { Broj=broj } };
            OperationResult rez = OperationMenager.Singleton.execute(op);         
        }
    }
}
