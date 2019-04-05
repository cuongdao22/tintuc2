using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Product()
        {
            ViewBag.abc = "ss";
            Models.TinTuc tin = new Models.TinTuc();
            tin.getTin();
            return View(tin);
        }
    }
}