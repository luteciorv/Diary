using System;
using System.Web.UI;

namespace Diary
{
    public partial class MainMasterPage : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Caso o usuário não tenha logado
            if (Request.Cookies["login"] == null)
            {
                // Redirecionar ele para a página inicial
                Response.Redirect("~/Views/Login.aspx");
            }
        }
    }
}