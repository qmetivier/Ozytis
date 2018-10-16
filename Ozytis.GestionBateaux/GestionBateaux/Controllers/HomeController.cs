using GestionBateaux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBateaux.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index( string type)
        {
            Dal dal = new Dal();
            List<GestionBateaux.Models.Bateau> bateaux = dal.ObtientToutLesBateaux();
            ViewData["Bateaux"] = bateaux;
            List<GestionBateaux.Models.Personne> personnes = dal.ObtientTouteLesPersonnes();
            ViewData["Personnes"] = personnes;
            List<GestionBateaux.Models.Role> roles = dal.ObtientToutLesRoles();
            ViewData["Roles"] = roles;
            List<GestionBateaux.Models.Type> types = dal.ObtientToutLesTypes();
            ViewData["Types"] = types;
            List<GestionBateaux.Models.Type_Role> typeRoles = dal.ObtientToutLesRoleTypes();
            ViewData["TypeRoles"] = typeRoles;
            switch (type)
            {
                case "gestionBateaux":
                    type = "AddBoat";
                    break;
                case "gestionPersonnes":
                    type = "AddPeople";
                    break;
                default:
                    type = "Index";
                    break;
            }
            return View(type);
        }
    }
}