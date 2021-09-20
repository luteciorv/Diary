using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiaryEntityFramework.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, Phone, StringLength(20)]
        public string Phone { get; set; }

        // Relacionamento => Usuário
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        // Método construtor #1
        public Contact() { }

        // Método construtor #2
        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        // Adicionar usuário
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        // Remover usuário
        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public override string ToString()
        {
            return "Oin";
        }
    }
}