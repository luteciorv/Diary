namespace DiaryEntityFramework.Migrations
{
    using DiaryEntityFramework.Data;
    using DiaryEntityFramework.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiaryEntityFramework.Data.DiaryEFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DiaryEFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if(context.User.Any() || context.Contact.Any()) { return; }            

            //== Contatos
            IList<Contact> contacts = new List<Contact>();

            Contact c1 = new Contact("Maria", "maria@gmail.com", "27998564125");
            Contact c2 = new Contact("Marcia", "marcia@gmail.com", "27991452");
            Contact c3 = new Contact("Estevão", "estevao@gmail.com", "27784525");
            Contact c4 = new Contact("Bernado", "bernado@gmail.com", "27998564125");
            Contact c5 = new Contact("Matheus", "matheus@gmail.com", "2799854502");
            Contact c6 = new Contact("Rosangela", "rosangela@gmail.com", "27981564125");
            Contact c7 = new Contact("Julia", "julia@gmail.com", "27999854725");
            Contact c8 = new Contact("Rômulo", "romulo@gmail.com", "27994564125");
            Contact c9 = new Contact("Arthur", "arthur@gmail.com", "27993574125");
            Contact c10 = new Contact("Mario", "mario@gmail.com", "27987104125");            

            contacts.Add(c1);
            contacts.Add(c2);
            contacts.Add(c3);
            contacts.Add(c4);
            contacts.Add(c5);
            contacts.Add(c6);
            contacts.Add(c7);
            contacts.Add(c8);
            contacts.Add(c9);
            contacts.Add(c10);

            //== Usuários
            IList<User> users = new List<User>();

            User u1 = new User(1123, "luis@gmail.com", "Luís", 21, "123456");
            User u2 = new User(14, "marcos@gmail.com", "Marcos", 11, "000000");
            User u3 = new User(115786, "flavia@gmail.com", "Flávia", 42, "12345678910");

            u1.AddContact(c1);
            u1.AddContact(c5);
            u1.AddContact(c2);
            u1.AddContact(c9);

            u2.AddContact(c1);
            u2.AddContact(c5);
            u2.AddContact(c10);

            users.Add(u1);
            users.Add(u2);
            users.Add(u3);

            // Adicionar nas tabelas
            context.User.AddRange(users);
            context.Contact.AddRange(contacts);

            // Salvar
            context.SaveChanges();
        }
    }
}
