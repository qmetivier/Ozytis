using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Type_Role
    {
        /// <summary>
        /// Identifiant utilisé pour retrouver le Type affecté
        /// </summary>
        [Key, Column(Order =0)]
        public int TypeId { get; set; }
        /// <summary>
        /// Identifiant utilisé pour retouver le Role affecté
        /// </summary>
        [Key, Column(Order = 1)]
        public int RoleId { get; set; }

        /// <summary>
        /// Type de bateau qui est question pour l'affectation du rôle
        /// </summary>
        public virtual Type Type { get; set; }
        /// <summary>
        /// Role utilisé par le Type de bateau qui est question
        /// </summary>
        public virtual Role Role { get; set; }
        /// <summary>
        /// Definie le Nombre de Personne minimal du Rôle en question pour le Type de bateau en question
        /// </summary>
        public int Nb_Role_min { get; set; }
        /// <summary>
        /// Definie le Nombre de Personne maximal du Rôle en question pour le Type de bateau en question
        /// </summary>
        public int Nb_Role_max { get; set; }
    }
}