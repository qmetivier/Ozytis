using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Type
    {
        /// <summary>
        /// Identifiant du Type de Bateau
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Intitulé du Type de Bateau
        /// </summary>
        [Required]
        public string Nom { get; set; }
    }
}