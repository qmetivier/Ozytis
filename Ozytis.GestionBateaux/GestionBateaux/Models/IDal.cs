using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBateaux.Models
{
    interface IDal : IDisposable
    {
        /// <summary>
        /// Prototype de la fonction créer un nouveau Bateau
        /// </summary>
        /// <param name="Nom"> Nom donnée au Bateau</param>
        /// <param name="IdType">Identifiant du Type du Bateau créé</param>
        void CreerBateau(string Nom, int IdType, List<string> personnes);
        /// <summary>
        /// Prototype de la fonction d'obtention des Bateaux dans la Bdd
        /// </summary>
        /// <returns>Liste des Bateaux présent dans la Bdd</returns>
        List<Bateau> ObtientToutLesBateaux();
        /// <summary>
        /// Prototype de la fonction créer une nouvelle Personne
        /// </summary>
        /// <param name="Nom">Nom donné au Personne</param>
        /// <param name="Prenom">Prénom donné au Personne</param>
        void CreerPersonne(string Nom, string Prenom, List<int> roles);
        /// <summary>
        /// Prototype de la fonction d'obtention des Personnes dans la Bdd
        /// </summary>
        /// <returns>Liste des Personnes présent dans la Bdd</returns>
        List<Personne> ObtientTouteLesPersonnes();
        /// <summary>
        /// Supprimer la Personne selectionnée
        /// </summary>
        /// <param name="id">Identifiant de la Personne à supprimer</param>
        void SupprimerPersonne(int id);
        /// <summary>
        /// Prototype de la fonction d'obtention des Roles des Personnes dans la Bdd
        /// </summary>
        /// <returns>Liste des Roles des Personnes présent dans la Bdd</returns>
        List<Role> ObtientToutLesRoles();
        /// <summary>
        /// Prototype de la fonction d'obtention des Types de Bateaux dans la Bdd
        /// </summary>
        /// <returns>Liste des Types de Bateaux présent dans la Bdd</returns>
        List<Type> ObtientToutLesTypes();
        /// <summary>
        /// Prototype de la fonction d'obtention des Role_Type dans la Bdd
        /// </summary>
        /// <returns>Liste des Role_Type présent dans la Bdd</returns>
        List<Type_Role> ObtientToutLesRoleTypes();
    }
}
