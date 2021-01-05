using SoporteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoporteWeb.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PrincipalController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Principal
        public ActionResult Index()
        {

            
            var costoes = db.Costos.ToList();
            return View(costoes);
        }
    }
}