using DiaryEntityFramework.Data;
using DiaryEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace DiaryEntityFramework.Services
{
    public class UserService
    {
        // Context do database
        private readonly DiaryEFContext _context;

        // Método construtor #1
        public UserService(DiaryEFContext context)
        {
            _context = context;
        }

        // Encontrar e retornar todos os usuários
        public async Task<List<User>> FindAllUsersAsync()
        {
            try
            {
                return await _context.User.ToListAsync();
            }

            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Adicionar usuário
        public async Task AddUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        // Remover usuário
        public async Task RemoveUserAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}