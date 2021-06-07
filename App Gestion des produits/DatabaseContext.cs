using App_Gestion_des_produits.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App_Gestion_des_produits
{
    class DatabaseContext: DbContext
    {
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Product.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
        public DbSet<Products> Products { get; set; }
    }
}
