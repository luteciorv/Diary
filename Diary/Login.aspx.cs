using System;
using System.Data.SqlClient;
using System.Web;
namespace Diary
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * Chamada quando o botão de login é clicado
         */
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            // Pegar o email e a senha passados
            string email = txbEmail.Text;
            string password = txbPassword.Text;

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
            cmd.CommandText = "SELECT * FROM [Users] WHERE Email = @Email AND Password = @Password";            
            cmd.Parameters.AddWithValue("Email", email);
            cmd.Parameters.AddWithValue("Password", password);

            // Abrir o banco de dados
            connection.Open();

            // Executar a consulta
            SqlDataReader register = cmd.ExecuteReader();

            // Verificar se retornou algo, isto é, o respectivo usuário
            if (register.HasRows)
            {
                // Armazenar o email do usuário no Cookie
                HttpCookie login = new HttpCookie("login", email);
                Response.Cookies.Add(login);

                // Redirecionar o usuário para a página principal
                Response.Redirect("~/Index.aspx");
            }

            // Usuário não encontrado
            else
            {
                Response.Write("<script> alert('Usuário ou senha inválidos'); </script>");                
            }            

            // Fechar conexão
            connection.Close();
        }
    }
}