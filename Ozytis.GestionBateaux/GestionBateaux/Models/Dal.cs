using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Bateau> ObtientToutLesBateaux()
        {
            return bdd.Bateaux.ToList();
        }
        public void CreerBateau(string nom, int idType)
        {
            Bateau bateau = new Bateau
            {
                Nom = nom,
                Type = bdd.Types.First(t => t.Id == idType)
            };
            bdd.SaveChanges();
        }

        public List<Personne> ObtientTouteLesPersonnes()
        {
            return bdd.Personnes.ToList();
        }

        public void CreerPersonne(string nom, string prenom)
        {
            Personne personne = new Personne
            {
                Nom = nom,
                Prenom = prenom
            };
            bdd.SaveChanges();
        }

        public List<Role> ObtientToutLesRoles()
        {
            return bdd.Roles.ToList();
        }
        public List<Type> ObtientToutLesTypes()
        {
            return bdd.Types.ToList();
        }
        public List<Type_Role> ObtientToutLesRoleTypes()
        {
            return bdd.Type_Roles.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}