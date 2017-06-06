using Mvc5Examples.Areas.Chapter03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter03.Controllers
{
    public class ch03DemosController : Controller
    {
        // GET: Chapter03/ch03Demos
        public ActionResult Index(string id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(id);
            }
            else
            {
                return View(id);
            }
        }

       // 例1
        public ActionResult ContentResultDemo1()
        {
            string s = string.Format("返回结果：{0:HH:mm:ss}", DateTime.Now);
            return Content(s);
        }
        public ActionResult ContentResultDemo2()
        {
            string s = "alert('Hello')";
            return Content(s, "text/javascript");
        }
        public ActionResult JavaScriptResultDemo()
        {
            return JavaScript("alert('Hello')");
        }
        [HttpPost]
        public ActionResult JsonResultDemo1()
        {
            string s = string.Format("返回结果：{0:HH:mm:ss}", DateTime.Now);
            return Json(s);
        }

        [HttpPost]
        public ActionResult JsonResultDemo2()
        {
            MyColorModel colorName = new MyColorModel { EnglishName = "red", ChineseName = "红色" };
            return Json(colorName);
        }
        public ActionResult FileResultDemo()
        {
            var downloadFile = File("~/Areas/Chapter03/downloadFiles/a1.docx", "application/vnd.ms-word", "a1.docx");
            return downloadFile;
        }

        public ActionResult RedirectResultDemos()
        {
            string url = Url.Action("Index", "ch03Demos", new { id = "ActionRendAction" });
            return Redirect(url);
        }

        //例2ViewBag ViewData
        public ActionResult ViewDataViewBag()
        {
            //单个数据
            ViewData["Name"] = "lhm";
            ViewBag.Name = "liuhm";
            //多个数据
            List<string> myColors = new List<string>
            {
                "red,红色","green,绿色","blue,蓝色"
            };
            ViewData["MyColors"] = myColors;
            ViewBag.MyColors = myColors;
            return PartialView();
        }

        public ActionResult ServerDemo()
        {
            var str = "<hello>,张三";
            ViewBag.Str = str;
            ViewBag.HtmlEncodeStr = Server.HtmlEncode(str);
            ViewBag.HtmlDecodeStr = Server.HtmlDecode(str);
            ViewBag.UrlEncodeStr = Server.UrlEncode(str);
            ViewBag.UrlDecodeStr = Server.UrlDecode(str);
            ViewBag.MapPath1 = Server.MapPath("~/Common/images");
            ViewBag.MapPath2 = Server.MapPath("Common/images");
            return PartialView();
        }

        public ActionResult RequestDemo()
        {
            string s = "";
            s += string.Format("<p>请求的URL：{0}</p>", Request.Url);
            string filePath = Request.FilePath;
            s += string.Format("<p>相对路径：{0}</p>", filePath);
            s += string.Format("<p>完整路径：{0}</p>", Request.MapPath(filePath));
            s += string.Format("<p>HTTP请求类型：{0}</p>", Request.RequestType);
            ViewBag.Result = MvcHtmlString.Create(s);
            return PartialView();
        }

        //ShowHello
        public ActionResult ShowHello(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return Content(string.Format("Hello,今天是{0:dddd}", DateTime.Now));

            }
            else
            {
                ViewBag.Message = "欢迎您，" + Server.HtmlEncode(name);
                return PartialView();
            }
        }

        //例9
        public ActionResult Example9(MyStudentModel student)
        {
            if(Request.HttpMethod=="GET")
            {
                student = new MyStudentModel
                {
                    XueHao = "001",
                    XingMing = "刘会敏",
                    XingBie = "女",
                    NianLing = 21
                };
                return PartialView(student);

            }
            else
            {
                string s = "输入有错！";
                if(ModelState.IsValid)
                {
                    s = string.Format(
                        "提交结果：学号：{0},姓名：{1}，性别：{2},年龄：{3}",
                        student.XueHao, student.XingMing, student.XingBie, student.NianLing);
                }
                return JavaScript(string.Format("alert('{0}')", s));
            }
        }


    }
}