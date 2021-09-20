using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Diary
{
    public partial class Contacts : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * Chamada quando o botão é clicado
         */
        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se todos os campos foram preenchidos
                if(txbEmail.Text != "" && txbName.Text != "" && txbPhone.Text != "")
                {
                    // Pegar a string de conexão
                    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                    System.Configuration.ConnectionStringSettings connectionString;
                    connectionString = rootWebConfig.ConnectionStrings.ConnectionStrings["Diary EF DatabaseConnectionString"];

                    // Criar um objeto de conexão
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = connectionString.ToString();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection
                    };

                    // Consulta
                    cmd.CommandText = "INSERT INTO Contacts (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
                    cmd.Parameters.AddWithValue("Name", txbName.Text);
                    cmd.Parameters.AddWithValue("Email", txbEmail.Text);
                    cmd.Parameters.AddWithValue("Phone", txbPhone.Text);

                    // Abrir o banco de dados, executar a consulta e fechar o banco de dados
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    // Atualizar o Grid View com os dados do novo contato
                    gvContacts.DataBind();

                    // Limpar os campos
                    txbName.Text = "";
                    txbEmail.Text = "";
                    txbPhone.Text = "";
                }

                else
                {
                    throw new Exception("Existem campos em branco");
                }
            }

            catch(Exception excep)
            {
                Response.Write("<script> alert('" + excep.Message + "'); </script>");
            }   
        }
    }
}