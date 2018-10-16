using GestionBateaux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GestionBateaux.Models
{
    public class Dal : IDal
    {
        /// <summary>
        /// Initialisation du BddContext
        /// </summary>
        private BddContext bdd;
        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Bateau> ObtientToutLesBateaux()
        {
            return bdd.Bateaux.ToList();
        }
        public void CreerBateau(string nom, int idType, List<string> personnes)
        {
            List<Personne> listAllPeople = ObtientTouteLesPersonnes();
            /*<input hidden="hidden" id="IdTargetPersonne" name="role[nbPersonne]" value="IdRole;IdTarget">*/

            Bateau bateau = new Bateau
            {
                Nom = nom,
                Type = bdd.Types.First(t => t.Id == idType)
                
            };

            foreach (var item in personnes)
            {
                Match matchPersonne = Regex.Match(item, @"\;([0-9]+)$",
                     RegexOptions.IgnoreCase);
                Match matchRole = Regex.Match(item, @"([0-9]+)\;$",
                     RegexOptions.IgnoreCase);
                if (matchPersonne.Success && matchRole.Success )
                {
                    int key = int.Parse(matchPersonne.Groups[1].Value);
                    Personne personne = (bdd.Personnes.First(p => p.Id == key));
                    personne.Bateau = bateau;
                    key = int.Parse(matchRole.Groups[1].Value);
                    personne.Id_Role_Bateau = bdd.Roles.First(r => r.Id == key).Id;
                    bdd.Personnes.Attach(personne);
                    bdd.Entry(personne).Property("bateau").IsModified = true;
                    bdd.Entry(personne).Property("Id_Role_Bateau").IsModified = true;
                }
            }
            bdd.Bateaux.Add(bateau);

            //Synchronise les changement avec la Bdd
            bdd.SaveChanges();
        }

        public List<Personne> ObtientTouteLesPersonnes()
        {
            return bdd.Personnes.ToList();
        }

        public void CreerPersonne(string nom, string prenom, List<int> roles)
        {
            /*<input hidden="hidden" id="IdTargetRole" name="role[nbRole]" value="IdTarget">*/
            List<Role> listRole = new List<Role>();
            foreach (var item in roles)
            {
                listRole.Add(bdd.Roles.First(r => r.Id == item));
            }

            Personne personne = new Personne
            {
                Nom = nom,
                Prenom = prenom,
                Roles = listRole,
                Id_Role_Bateau = -1
            };
            bdd.Personnes.Add(personne);
            //Synchronise les changement avec la Bdd
            bdd.SaveChanges();
        }

        public void SupprimerPersonne(int id)
        {
            /*Personne personne = bdd.Personnes.Where(p => p.Id == id).First();
            bdd.Personnes.Remove(bdd.Personnes.Where(p => p.Id == id).First());
            bdd.SaveChanges();*/
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

        ///libére les ressources non managées utilisées
        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}