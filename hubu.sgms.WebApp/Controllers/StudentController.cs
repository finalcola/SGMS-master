using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
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
        private IStudentService studentService = StudentServiceImpl.Instance();

        // GET: Student
        public ActionResult Index()
        {
            //student_address: location,
            //student_name: $("#student_name").val(),
            //student_id_card: $("#student_id_card").val(),
            //student_phone: $("#student_phone").val(),
            //student_email: $("#student_email").val(),
            //student_other: $("#student_other").val()
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

        public ActionResult ChangeInfo(string student_name, string student_address, string student_id_card,
            string student_phone, string student_other, string student_email)
        {
            return Json(new { status = 1 });
        }

        public ActionResult ChangePassPage()
        {
            return View();
        }

        #region 跳转到学籍信息页面
        public ActionResult InfoPage()
        {
            Login login = (Login)Session["loginInfo"];
            //if (login == null)
            //{
            //    //未登录
            //    //跳转到登录页面
            //    Session["prePage"] = "/Student/Index";//将当前页面地址放入session，登录后返回到该页面
            //    return RedirectToAction("Index", "Login");
            //}

            //string username = login.username;
            string username = "201702";

            Student student = studentService.GetStudentById(username);
            ViewData["student"] = student;
            return View();
        }
        #endregion
    }
}