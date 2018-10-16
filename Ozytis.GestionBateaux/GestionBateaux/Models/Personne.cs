using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Personne
    {
        /// <summary>
        /// Identifiant de Personne
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom de famille de Personne
        /// </summary>
        [Required]
        public string Nom { get; set; }
        /// <summary>
        /// Prenom de Personne
        /// </summary>
        [Required]
        public string Prenom { get; set; }
        /// <summary>
        /// L'id Role de la Personne sur le Bateau auquel il est affecté
        /// </summary>
        public virtual int Id_Role_Bateau { get; set; } 
        /// <summary>
        /// Bateau auquel Personne est affecté
        /// </summary>
        public virtual Bateau Bateau { get; set; }
        /// <summary>
        /// Liste des rôles auquel Personne est affecté
        /// </summary>
        public virtual List<Role> Roles { get; set; }
    }
}