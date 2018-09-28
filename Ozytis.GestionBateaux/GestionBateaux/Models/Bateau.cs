using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Bateau
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual Type Type { get; set; }
    }
}