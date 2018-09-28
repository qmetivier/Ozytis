using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Bateau> Bateaux { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type_Role> Type_Roles { get; set; }

    }
}