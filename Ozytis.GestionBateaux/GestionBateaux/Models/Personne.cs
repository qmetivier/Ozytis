using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public virtual Bateau Bateau { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}