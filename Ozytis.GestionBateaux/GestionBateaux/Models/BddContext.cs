using System;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class BddContext : DbContext
    {
        /// <summary>
        /// Ajoute dans le context la table Bateau
        /// </summary>
        public DbSet<Bateau> Bateaux { get; set; }
        /// <summary>
        /// Ajoute dans le context la table Personne
        /// </summary>
        public DbSet<Personne> Personnes { get; set; }
        /// <summary>
        /// Ajoute dans le context la table Type
        /// </summary>
        public DbSet<Type> Types { get; set; }
        /// <summary>
        /// Ajoute dans le context la table Role
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// Ajoute dans le context la table Type_Role
        /// </summary>
        public DbSet<Type_Role> Type_Roles { get; set; }

    }
}