using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Role
    {
        /// <summary>
        /// Identifiant du Rôle
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Intitulé du Rôle
        /// </summary>
        [Required]
        public string Nom { get; set; }
        /// <summary>
        /// Liste des Personnes qui possèdent ce Rôle
        /// </summary>
        public virtual List<Personne> Personnes { get; set; }

    }
}