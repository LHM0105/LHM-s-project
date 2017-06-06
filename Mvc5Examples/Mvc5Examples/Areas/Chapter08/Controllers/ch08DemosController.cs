using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter08.Controllers
{
    public class ch08DemosController : Controller
    {
        // GET: Chapter08/ch08Demos
        public ActionResult Index(string id)
        {
            if(Request.IsAjaxRequest())
            {
                return PartialView(id);
            }
            else
            {
                return View(id);
            }
            
        }

    }
}