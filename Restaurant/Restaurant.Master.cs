using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class Restaurant : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                LoginStatus1.Visible = true;
                Login1.Visible = false;
                labelLogutText.Visible = true;
            }
        }

       
        
    }
}