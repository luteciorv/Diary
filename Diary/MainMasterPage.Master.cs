using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class MainMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Caso o usuário não tenha logado
            if (Request.Cookies["login"] == null)
            {
                // Redirecionar ele para a página inicial
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}