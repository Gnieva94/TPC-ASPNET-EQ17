using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Form
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = Session["Error"] != null? Session["Error"].ToString():"Puede que no exista error alguno.";
            Response.AppendHeader("Refresh", "5;url=default.aspx");
        }
    }
}