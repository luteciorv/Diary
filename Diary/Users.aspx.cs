using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diary
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * Chamada depois que algum dado é inserido
         */
        protected void SqlDataSourceUsers_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            // Verificar se ocorreu alguma exceção
            if (e.Exception != null)
            {
                // Exibir mensagem de erro                
                Response.Write("<script> alert('Erro! Email já cadastrado ou campo em branco'); </script>");

                // Exceção tratada
                e.ExceptionHandled = true;
            }

            // Caso não tenha ocorrido
            else
            {
                lMessage.Text = "";
            }
        }

        /*
         * Chamada depois que algum dado é atualizado
         */
        protected void SqlDataSourceUsers_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            // Verificar se ocorreu alguma exceção
            if (e.Exception != null)
            {
                // Exibir mensagem de erro                
                Response.Write("<script> alert('Campo em branco.'); </script>");

                // Exceção tratada
                e.ExceptionHandled = true;
            }

            // Caso não tenha ocorrido
            else
            {
                lMessage.Text = "";
            }
        }
    }
}