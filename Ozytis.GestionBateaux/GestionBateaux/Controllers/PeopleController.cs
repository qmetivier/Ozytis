using GestionBateaux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBateaux.Controllers
{
    public class PeopleController : Controller
    {
        Dal dal = new Dal();
        // GET: People
        [HttpPost]
        public ActionResult AddOrModify(int? id, string FirstPeople, string LastName, List<int> role)
        {
            dal.CreerPersonne(FirstPeople, LastName, role);

            return Redirect("../../Home/Index/gestionPersonnes");
        }

        public ActionResult Delete(int id)
        {
            dal.SupprimerPersonne(id);

            return RedirectToRoute("../../Home/Index/gestionPersonnes");
        }
    }
}