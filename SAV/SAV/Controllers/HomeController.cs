using SAV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAV.Controllers
{
    public class HomeController : Controller
    {
        private SAVEntities db = new SAVEntities();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Menu.ToList());
        }
    }
}