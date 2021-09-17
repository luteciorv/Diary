using DiaryEntityFramework.Data;
using DiaryEntityFramework.Models;
using DiaryEntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiaryEntityFramework.Views
{
    public partial class Users : System.Web.UI.Page
    {
        private readonly DiaryEFContext _context = new DiaryEFContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { return; }

            // Popular o Drop Down List dos contatos
            PopulateDDLContacts();            
        }

        // O tipo de retorno pode ser alterado para IEnumerable, no entanto, para dar suporte à paginação de
        // e classificação, os seguintes parâmetros devem ser adicionados:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public async Task<List<User>> GetUsersAsync()
        {
            UserService userService = new UserService(_context);
            var query = await userService.FindAllUsersAsync();
            return query;
        }

        // O nome do parâmetro id deve corresponder ao valor DataKeyNames definido no controle
        public void UpdateItem(int id)
        {
            // Acessar o Context do database
            using (var context = new DiaryEFContext())
            {
                // Pegar o usuário com o Id fornecido
                User user = context.User.Find(id);

                // Caso não tenha encontrado
                if (user == null)
                {
                    ModelState.AddModelError("", String.Format("O item com id {0} não foi encontrado", id));
                    return;
                }

                // Tentar atualizar os valores do usuário
                TryUpdateModel(user);

                // Caso tenha conseguido
                if (ModelState.IsValid)
                {
                    // Salve alterações no Database
                    context.SaveChanges();

                    // Atualizar todos os ListView e GridView da página
                    DataBind();
                }
            }

        }

        // O nome do parâmetro id deve corresponder ao valor DataKeyNames definido no controle
        public void DeleteItem(int id)
        {
            // Acessar o Context do database
            using (var context = new DiaryEFContext())
            {
                // Pegar o usuário com o Id fornecido
                User user = context.User.Find(id);

                // Caso não tenha encontrado
                if (user == null)
                {
                    ModelState.AddModelError("", String.Format("O item com id {0} não foi encontrado", id));
                    return;
                }

                // Deletar
                context.User.Remove(user);

                try
                {
                    // Salvar as alterações
                    context.SaveChanges();

                    // Atualizar todos os ListView e GridView da página
                    DataBind();
                }

                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", $"O usuário com o id {id} não existe no banco de dados");
                }
            }
        }

        protected async void BtnAdd_ClickAsync(object sender, EventArgs e)
        {
            // Pegar as informações
            int id = int.Parse(txbId.Text);
            string email = txbEmail.Text;
            string passoword = txbPassword.Text;
            string name = txbName.Text;
            int age = int.Parse(txbAge.Text);
            int contactId = int.Parse(ddlContact.SelectedValue);

            // Verificar se o Id informado já existe
            if(_context.User.Where(u => u.Id == id).Any())
            {
                // Mostrar mensagem
                lErrorAddUser.Text = $"Id: {id} já foi cadastrado";

                // Limpar campo de Id
                txbId.Text = "";

                // Retornar
                return;
            }

            // Criar usuário
            User user = new User(id, email, name, age, passoword);
            user.AddContact(_context.Contact.Where(c => c.Id == contactId).FirstOrDefault());

            // Adicionar usuário
            UserService userService = new UserService(_context);
            await userService.AddUserAsync(user);

            // Recarregar página
            Response.Redirect("~/Views/Users.aspx");
        }

        protected void BtnClean_Click(object sender, EventArgs e)
        {
            // Limpar todos os campos
            txbId.Text = "";
            txbEmail.Text = "";
            txbPassword.Text = "";
            txbName.Text = "";
            txbAge.Text = "";
           ddlContact.SelectedValue = "";
        }

        private void PopulateDDLContacts()
        {
            // Contatos=> Id, Nome
            var contacts = _context.Contact.Select(c => new { c.Id, c.Name }).ToList();
            ddlContact.DataSource = contacts;

            // Id
            ddlContact.DataValueField = "Id";

            // Nome
            ddlContact.DataTextField = "Name";

            // Atualizar
            ddlContact.DataBind();

            // Valor padrão
            ddlContact.Items.Insert(0, new ListItem("----- Contatos -----"));
        }
    }
}









