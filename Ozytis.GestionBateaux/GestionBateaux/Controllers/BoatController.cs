using GestionBateaux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBateaux.Controllers
{
    public class BoatController : Controller
    {
        Dal dal = new Dal();
        // GET: Boat
        [HttpPost]
        public ActionResult AddOrModify(int? id, string nom, int idType , List<string> personnes)
        {
            dal.CreerBateau(nom, idType, personnes);

            return Redirect("../../Home/Index/gestionBateaux");
        }

        public ActionResult Delete(int id)
        {
            //dal.supprimerBateau(id);

            return RedirectToRoute("../../Home/Index/gestionBateaux");
        }
    }
}