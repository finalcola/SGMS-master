using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Student/Index";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public ActionResult ChangeInfo()
        {
            return Json(new { status = 1 });
        }

        public ActionResult ChangePassPage()
        {
            return View();
        }

        public ActionResult ChangePass()
        {
            return Json(new { status = 1 });
        }
    }
}