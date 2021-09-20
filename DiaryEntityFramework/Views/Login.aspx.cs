using DiaryEntityFramework.Data;
using DiaryEntityFramework.Services;
using System;
using System.Web;
using System.Web.UI;

namespace DiaryEntityFramework.Views
{
    public partial class Login : Page
    {
        // Context do banco de dados
        private readonly DiaryEFContext _context = new DiaryEFContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void BtnLogin_ClickAsync(object sender, EventArgs e)
        {
            // Pegar as informações do login
            string email = txbEmail.Text;
            string password = txbPassword.Text;

            // Instanciar o serviço de usuários
            UserService userService = new UserService(_context);

            // Pegar todos os usuáriso cadastrados
            var users = await userService.FindAllUsersAsync();

            // Procurar o usuário informado
            if(users.Find(u =>  u.Email == email && u.Password == password) != null)
            {
                // Logar no site
                // Armazenar o email do usuário no Cookie
                HttpCookie login = new HttpCookie("login", email);
                Response.Cookies.Add(login);

                // Redirecionar o usuário para a página principal
                Response.Redirect("~/Views/Index.aspx");
            }

            // Usuário não encontrado
            else
            {
                Response.Write("<script> alert('Usuário ou senha inválidos'); </script>");
            }
        }
    }
}