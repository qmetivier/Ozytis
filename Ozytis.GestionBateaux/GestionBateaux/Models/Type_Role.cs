using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionBateaux.Models
{
    public class Type_Role
    {
        public virtual Type Type_Id { get; set; }
        public virtual Role Role_Id { get; set; }
        public int Nb_Role { get; set; }
    }
}