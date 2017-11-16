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
    public class LoginController : Controller
    {

        ILoginService loginService = new LoginServiceImpl();
        ITeacherService teacherService = new TeacherServiceImpl();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            //添加相应的验证码代码

            //验证系统是否是开启状态 0--关闭 1--开启
            Status status = teacherService.GetAllStatus();
            if(status.global_status == "0")
            {
                return Json(new { status = "3", msg = "系统已经关闭，请联系管理员！" });
            }

            string username = Request["username"];
            string password = Request["password"];

            Login loginInfo = loginService.GetUser(username, password);

            if (loginInfo != null)
            {
                Session["loginInfo"] = loginInfo;
                if (Session["prePage"] != null)
                {
                    string prePage = (string)Session["prePage"];//登陆前，访问的页面
                    Session["prePage"] = null;
                    return Json(new { status = "1", successUrl = prePage });
                }
                //return Content("success:登陆成功！");
                //TODO  不同角色的处理
                string successUrl = null;
                string role = loginInfo.role;
                switch (role)
                {
                    case "admin":
                        successUrl = "/Admin/Index";
                        break;
                    case "teacher":
                        successUrl = "/Teacher/TeacherManager";
                        break;
                    case "student":
                        successUrl = "/Student/Index"; 
                        break;
                    default:
                        return Json(new { status = "0", msg = "身份不合法!" });
                }

                return Json(new { status = "1", successUrl = successUrl });//跳转到后台管理页面
            }
            else
            {
                //return Content("error:登陆失败！");
                return Json(new { status = "0", msg = "用户名或密码错误" } );
            }
        }

        public ActionResult ChangePass(string password)
        {
            if(password==null || "".Equals(password))
            {
                return Json(new { status = 0, msg = "缺少密码!" });
            }

            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                return Json(new { status = 0, msg = "请先登录!" });
            }

            //try
            //{
            //    string username = login.username;
            //    loginService.ChangePass(username, password);
            //    return Json(new { status = 1, msg = "OK!" });
            //}
            //catch (Exception)
            //{
            //    return Json(new { status = 0, msg = "Failed!" });
            //}
            string username = login.username;
            loginService.ChangePass(username, password);
            return Json(new { status = 1, msg = "OK!" });
        }
    }
}