using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBateaux.Models
{
    interface IDal : IDisposable
    {
        void CreerBateau(string Nom, int IdType);
        List<Bateau> ObtientToutLesBateaux();
        void CreerPersonne(string Nom, string Prenom);
        List<Personne> ObtientTouteLesPersonnes();
        List<Role> ObtientToutLesRoles();
        List<Type> ObtientToutLesTypes();
        List<Type_Role> ObtientToutLesRoleTypes();
    }
}
