using DiaryEntityFramework.Data;
using DiaryEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DiaryEntityFramework.Services
{
    public class ContactService
    {
        // Context do banco de dados
        private readonly DiaryEFContext _context;

        // Método construtor #1
        public ContactService(DiaryEFContext context)
        {
            _context = context;
        }

        // Adicionar um contato
        public async Task AddContactAsync(Contact contact)
        {
            try
            {
                // Adicionar
                _context.Contact.Add(contact);

                // Salvar
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Remover um contato
        public async Task RemoveContactAsync(int id)
        {
            try
            {
                // Encontrar contato
                Contact contact = await _context.Contact.FindAsync(id);

                // Remover
                _context.Contact.Remove(contact);

                // Salvar
                await _context.SaveChangesAsync();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Encontrar um contato
        public async Task<Contact> FindContactAsync(int id)
        {
            try
            {
                return await _context.Contact.FindAsync(id);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Encontrar todo os contatos
        public async Task<List<Contact>> FindAllContactsAsync()
        {
            try
            {
                return await _context.Contact.ToListAsync();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }           
        }
    }
}