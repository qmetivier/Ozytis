using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Bateau
    {
        /// <summary>
        /// Identifiant du Bateau
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom du Bateau
        /// </summary>
        [Required]
        public string Nom { get; set; }
        /// <summary>
        /// Représente le Type du Bateau
        /// </summary>
        [Required]
        public virtual Type Type { get; set; }
    }
}