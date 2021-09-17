using DiaryEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiaryEntityFramework.Data
{
    public class DiaryEFContext : DbContext
    {
        // Método construtor #1
        public DiaryEFContext() : base("Diary EF Database") { }

        // Tabelas
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}