using DiaryEntityFramework.Data;
using DiaryEntityFramework.Models;
using DiaryEntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiaryEntityFramework.Views
{
    public partial class Contacts : System.Web.UI.Page
    {
        // Context do banco de dados
        private readonly DiaryEFContext _context = new DiaryEFContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Pega todos os contatos
        public async Task<List<Contact>> GridContacts_GetDataAsync()
        {
            // Instanciar service dos contatos
            ContactService contactService = new ContactService(_context);

            // Consultar
            var query = await contactService.FindAllContactsAsync();

            // Retornar contato
            return query;
        }

        // Atualiza um contato com o Id pego
        public async Task GridContacts_UpdateItemAsync(int id)
        {
            // Instanciar service de contatos
            ContactService contactService = new ContactService(_context);

            // Pegar contato
            Contact contact = await contactService.FindContactAsync(id);

            // Verificar se o contato existe
            if (contact == null)
            {
                // O item não foi encontrado
                ModelState.AddModelError("", String.Format("O item com id {0} não foi encontrado", id));
                return;
            }

            // Tentar atualizar
            TryUpdateModel(contact);

            if (ModelState.IsValid)
            {
                // Salvar
                await _context.SaveChangesAsync();
            }
        }

        // Deleta um contato com o Id pego
        public async Task GridContacts_DeleteItemAsync(int id)
        {
            // Instanciar service dos contatos
            ContactService contactService = new ContactService(_context);

            // Pegar o contato com o Id fornecido
            Contact contact = await contactService.FindContactAsync(id);

            // Caso não tenha encontrado
            if (contact == null)
            {
                ModelState.AddModelError("", string.Format("O item com id {0} não foi encontrado", id));
                return;
            }

            // Remover contato
            await contactService.RemoveContactAsync(id);

            // Atualizar todos os ListView e GridView da página
            DataBind();
        }

        // Adiciona um contato com as informações passadas no TextBox
        protected async void BtnInsert_ClickAsync(object sender, EventArgs e)
        {
            // Pegar as informações dos campos de texto
            string name = txbName.Text;
            string email = txbEmail.Text;
            string phone = txbPhone.Text;

            // Criar um novo contato
            Contact contact = new Contact(name, email, phone);

            // Instanciar um serviço de contato
            ContactService contactService = new ContactService(_context);

            // Adicionar contato
            await contactService.AddContactAsync(contact);

            // Atualizar os dados
            GridContacts.DataBind();

            // Apagar os campos
            txbName.Text = "";
            txbEmail.Text = "";
            txbPhone.Text = "";
        }
    }
}