using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiaryEntityFramework.Models
{
    public class User
    {
        // Atributos
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [EmailAddress(), StringLength(100), Required]
        public string Email { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required, MinLength(6), MaxLength(20)]
        public string Password { get; set; }

        // Relacionamento => Contato
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        // Método construtor #1
        public User() { }

        public User(int id, string email, string name, int age, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            Age = age;
            Password = password;
        }

        // Adicionar um contato
        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        // Remover um contato
        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        // Encontrar um contato pelo Id
        public Contact FindContactById(int id)
        {
            return Contacts.Where(c => c.Id == id).First();
        }

        public string GetAllContacts()
        {
            List<string> names = Contacts.Select(c => c.Name).ToList();
            string allNames = "";

            foreach(string name in names)
            {
                allNames += name + ", ";
            }

            return names.Any() ? allNames : "Não possui contatos";
        }
    }
}