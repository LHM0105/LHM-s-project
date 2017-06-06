using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter06.Controllers
{
    public class ch06DemosController : Controller
    {
        // GET: Chapter06/ch06Demos
        //ch06Index调用的方法
        public ActionResult Index(string id)
        {
            return View(id);
        }

        //本章示例调用的方法
        public ActionResult Index1(string id)
        {
            return PartialView(id);
        }
    }
}